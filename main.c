
#define HSE_VALUE ((uint32_t)8000000) /* STM32 discovery uses a 8Mhz external crystal */
#include "misc.h"
#include "stm32f4xx_conf.h"
#include "stm32f4xx.h"
#include "stm32f4xx_gpio.h"
#include "stm32f4xx_rcc.h"
#include "stm32f4xx_exti.h"
#include "stm32f4xx_tim.h"
#include "usbd_cdc_core.h"
#include "stm32f4xx_syscfg.h"
#include "usbd_usr.h"
#include "usbd_desc.h"
#include "usbd_cdc_vcp.h"
#include "usb_dcd_int.h"
#include "defines.h"
#include "tm_stm32f4_delay.h"
#include "tm_stm32f4_hd44780.h"
#include "stm32f4xx_adc.h"



volatile uint32_t ticker, downTicker;
int switcher=0;
int flag  = 0;
int user_flag =0;
char msg[5][256];
int pom =0;
int pom2 = 0;
char user[32];
char user_pom[32];
char data[2048];
char view[256];
char date[32];
int index=0;
/*
 * The USB data must be 4 byte aligned if DMA is enabled. This macro handles
 * the alignment, if necessary (it's actually magic, but don't tell anyone).
 */
__ALIGN_BEGIN USB_OTG_CORE_HANDLE  USB_OTG_dev __ALIGN_END;


void init();
void ColorfulRingOfDeath(void);

/*
 * Define prototypes for interrupt handlers here. The conditional "extern"
 * ensures the weak declarations from startup_stm32f4xx.c are overridden.
 */
#ifdef  __cplusplus
 extern "C" {
#endif

void SysTick_Handler(void);
void NMI_Handler(void);
void HardFault_Handler(void);
void MemManage_Handler(void);
void BusFault_Handler(void);
void UsageFault_Handler(void);
void SVC_Handler(void);
void DebugMon_Handler(void);
void PendSV_Handler(void);
void OTG_FS_IRQHandler(void);
void OTG_FS_WKUP_IRQHandler(void);

#ifdef __cplusplus
}
#endif



 void TIM2_IRQHandler(void)
 {
          	if(TIM_GetITStatus(TIM2, TIM_IT_Update) != RESET)
          	{
          		if(GPIO_ReadInputDataBit(GPIOD, GPIO_Pin_0) != RESET)
          		{
          			GPIO_SetBits(GPIOD, GPIO_Pin_13);
  	          		switcher++;
	          		if(switcher == 6)
	          			switcher = 0;
	          		flag=1;
          		}
          		GPIO_ResetBits(GPIOD, GPIO_Pin_13);
          		TIM_Cmd(TIM2, DISABLE);
          		TIM_SetCounter(TIM2, 0);
                TIM_ClearITPendingBit(TIM2, TIM_IT_Update);
          	}
 }

 void TIM4_IRQHandler(void)
 {
          	if(TIM_GetITStatus(TIM4, TIM_IT_Update) != RESET)
          	{
          		if(GPIO_ReadInputDataBit(GPIOC, GPIO_Pin_1) != RESET)
          		{
          			GPIO_SetBits(GPIOD, GPIO_Pin_15);
          			switcher--;
       				if(switcher < 0)
          		       switcher=5;
          		    flag=1;
				}
          		GPIO_ResetBits(GPIOD, GPIO_Pin_15);
          		TIM_Cmd(TIM4, DISABLE);
          		TIM_SetCounter(TIM4, 0);
          		TIM_ClearITPendingBit(TIM4, TIM_IT_Update);
          	}
 }

 void EXTI1_IRQHandler(void)
 {
          	if(EXTI_GetITStatus(EXTI_Line1) != RESET)
          	{
          		TIM_Cmd(TIM4, ENABLE);
         	   	EXTI_ClearITPendingBit(EXTI_Line1);
    	   	}
 }

void EXTI0_IRQHandler(void)
  {
           	if(EXTI_GetITStatus(EXTI_Line0) != RESET)
           	{
           		TIM_Cmd(TIM2, ENABLE);
           		EXTI_ClearITPendingBit(EXTI_Line0);
     	   	}
  }


void update()
{
	for (int i = 4; i >= 0; i--)
	{
		for (int j = 0; j < 256; j++)
		{
			msg[i + 1][j] = msg[i][j];
			msg[i][j] = ' ';
		}
	}
}

int main(void)
{
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOC, ENABLE);
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);
		RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM4, ENABLE);
		RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_SYSCFG, ENABLE);
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_ADC1, ENABLE);

		GPIO_InitTypeDef  GPIO_InitStructure;
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12 | GPIO_Pin_13| GPIO_Pin_14| GPIO_Pin_15;
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
		GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
		GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
		GPIO_Init(GPIOD, &GPIO_InitStructure);

		GPIO_InitStructure.GPIO_Pin = GPIO_PIN_1;
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
		GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
		GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_DOWN;
		GPIO_Init(GPIOC, &GPIO_InitStructure);

		GPIO_InitStructure.GPIO_Pin = GPIO_PIN_0;
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
		GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
		GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_DOWN;
		GPIO_Init(GPIOD, &GPIO_InitStructure);

		GPIO_InitStructure.GPIO_Pin = GPIO_PIN_0;
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
		GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
		GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_DOWN;
		GPIO_Init(GPIOA, &GPIO_InitStructure);

		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_1;
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AN;
		GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
		GPIO_Init(GPIOA, &GPIO_InitStructure);

		ADC_CommonInitTypeDef ADC_CommonInitStructure;
		ADC_CommonInitStructure.ADC_Mode = ADC_Mode_Independent;
		ADC_CommonInitStructure.ADC_Prescaler = ADC_Prescaler_Div2;
		ADC_CommonInitStructure.ADC_DMAAccessMode = ADC_DMAAccessMode_Disabled;
		ADC_CommonInitStructure.ADC_TwoSamplingDelay = ADC_TwoSamplingDelay_5Cycles;
		ADC_CommonInit(&ADC_CommonInitStructure);

		ADC_InitTypeDef ADC_InitStructure;
		ADC_InitStructure.ADC_Resolution = ADC_Resolution_12b;
		ADC_InitStructure.ADC_ScanConvMode = DISABLE;
		ADC_InitStructure.ADC_ContinuousConvMode = ENABLE;
		ADC_InitStructure.ADC_ExternalTrigConv = ADC_ExternalTrigConv_T1_CC1;
		ADC_InitStructure.ADC_ExternalTrigConvEdge = ADC_ExternalTrigConvEdge_None;
		ADC_InitStructure.ADC_DataAlign = ADC_DataAlign_Right;
		ADC_InitStructure.ADC_NbrOfConversion = 1;


		ADC_Init(ADC1, &ADC_InitStructure);
		ADC_RegularChannelConfig(ADC1, ADC_Channel_1, 1, ADC_SampleTime_84Cycles);
		ADC_Cmd(ADC1, ENABLE);

		TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
		TIM_TimeBaseStructure.TIM_Period = 8399;
		TIM_TimeBaseStructure.TIM_Prescaler = 999;
		TIM_TimeBaseStructure.TIM_ClockDivision = TIM_CKD_DIV1;
		TIM_TimeBaseStructure.TIM_CounterMode =  TIM_CounterMode_Up;
		TIM_TimeBaseInit(TIM4, &TIM_TimeBaseStructure);


		TIM_TimeBaseStructure.TIM_Period = 8399;
		TIM_TimeBaseStructure.TIM_Prescaler = 999;
		TIM_TimeBaseStructure.TIM_ClockDivision = TIM_CKD_DIV1;
		TIM_TimeBaseStructure.TIM_CounterMode =  TIM_CounterMode_Up;
		TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);

		NVIC_PriorityGroupConfig(NVIC_PriorityGroup_1);
		NVIC_InitTypeDef NVIC_InitStructure;
		NVIC_InitStructure.NVIC_IRQChannel = TIM4_IRQn;
		NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x00;
		NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x00;
		NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
		NVIC_Init(&NVIC_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;
		NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x00;
		NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x00;
		NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
		NVIC_Init(&NVIC_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = EXTI1_IRQn;
		NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x00;
		NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x00;
		NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
		NVIC_Init(&NVIC_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = EXTI0_IRQn;
		NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x00;
		NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x00;
		NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
		NVIC_Init(&NVIC_InitStructure);

		EXTI_InitTypeDef EXTI_InitStructure;
		EXTI_InitStructure.EXTI_Line = EXTI_Line1;
		EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
		EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;
		EXTI_InitStructure.EXTI_LineCmd = ENABLE;
		EXTI_Init(&EXTI_InitStructure);

		EXTI_InitStructure.EXTI_Line = EXTI_Line0;
		EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
		EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;
		EXTI_InitStructure.EXTI_LineCmd = ENABLE;
		EXTI_Init(&EXTI_InitStructure);

		TIM_ClearITPendingBit(TIM4, TIM_IT_Update);
		TIM_ITConfig(TIM4, TIM_IT_Update, ENABLE);

		TIM_ClearITPendingBit(TIM2, TIM_IT_Update);
		TIM_ITConfig(TIM2, TIM_IT_Update, ENABLE);

		SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOC, EXTI_PinSource1);
		SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOD, EXTI_PinSource0);
		EXTI_ClearITPendingBit(EXTI_Line1);
		EXTI_ClearITPendingBit(EXTI_Line0);

	/* Set up the system clocks */
	SystemInit();

	/* Initialize USB, IO, SysTick, and all those other things you do in the morning */
	init();
	/* Set up LCD */
	TM_HD44780_Init(20, 4);


	for(int i = 0; i < 32; i++)
	{
		date[i] = ' ';
		user[i] = ' ';
		user_pom[i] = ' ';
	}

	for(int j = 0; j < 4;j++){
		for(int i = 0; i<256; i++){
			view[i] = ' ';
			msg[j][i] = ' ';

		}
	}
	for(;;)
	{

		Delayms(700);
		TM_HD44780_ScrollLeft();

		if(GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_0) != RESET && user_flag == 1)
		{
			TM_HD44780_Clear();
			TM_HD44780_PutsVCP(0,0,user);
			TM_HD44780_PutsVCP(0,1,date);
			user_flag=2;
			Delayms(1000);
		}
		else if (GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_0) != RESET && user_flag != 1)
		{
			TM_HD44780_Clear();
			for(int i = 0; i < 80; i++)
				view[i] = msg[0][i];
			TM_HD44780_PutsVCP(0,0,view);
			Delayms(1000);
		}

		if (VCP_get_string(data))
		{

			VCP_send_str(data);
			TM_HD44780_Clear();
			TM_HD44780_Puts(0,0, "NOWE POWIADOMIENIE!");
			TM_HD44780_Puts(0,1, "NACISNIJ 'USER', ABY WYSWIETLIC!");
			for(int i = 0; i <2048; i++)
			{

				if(data[i]=='=')
				{
					if(data[i-3] == 'u' && data[i-2]=='s' && data[i-1] == 'r')
					{
						pom = 0;
						pom2 = i+1;
						while(data[pom2] != '$'){
							user[pom] = data[pom2];
							pom++;
							pom2++;
							}
							user[pom+1] = '$';
						user_flag = 1;
						for(int i = 0; i < 32; i++)
							user_pom[i] = user[i];
					}
					else if(data[i-3] == 'm' && data[i-2]=='s' && data[i-1] == 'g')
					{
						if(index==5)
						{
							update();
							pom = 0;
							pom2 = i+1;
							while(data[pom2] != '$'){
								if (pom == 39){
									msg[0][39] = ' ';
									pom++;
								}
								msg[0][pom] = data[pom2];
								pom++;
								pom2++;
								}
							if(pom > 80)
							{
								msg[0][76] = '.';
								msg[0][77] = '.';
								msg[0][78] = '.';
								msg[0][79] = '$';
							}
							else
							msg[0][pom+1] = '$';

							for(int i =0; i<32;i++)
									user[i] = user_pom[i];
						}
						else
						{
							pom = 0;
							pom2 = i+1;
							while(data[pom2] != '$')
							{
								if (pom == 39){
									msg[index][39] = ' ';
									pom++;
								}
								msg[index][pom] = data[pom2];
								pom++;
								pom2++;
							}
							if(pom > 80)
							{
								msg[index][76] = '.';
								msg[index][77] = '.';
								msg[index][78] = '.';
								msg[index][79] = '$';
							}
							else
								msg[index][pom+1] = '$';
							index++;
						}
					}
					else if(data[i-3] == 'd' && data[i-2]=='a' && data[i-1] == 't')
					{
						pom = 0;
						pom2 = i+1;
						while(data[pom2] != '$'){
							date[pom] = data[pom2];
							pom++;
							pom2++;
							}
							date[pom+1] = '$';
					}
				}
			}
						for(int i = 0; i<2048; i++)
							data[i] = ' ';

		}
		else {
			if(switcher != 0 && flag == 1){
			TM_HD44780_Clear();
			for(int i = 0; i < 80; i++)
			  	view[i] = msg[switcher-1][i];

			TM_HD44780_PutsVCP(0,0,view);
			flag=0;
			Delayms(1000);
			}
			else if (switcher == 0 && flag == 1) {
			TM_HD44780_Clear();
			TM_HD44780_PutsVCP(0,0,user);
			TM_HD44780_PutsVCP(0,1,date);
			flag=0;
			Delayms(1000);
			}
		}


	}

	return 0;
}


void init()
{
	/* STM32F4 discovery LEDs */
	GPIO_InitTypeDef LED_Config;

	/* Always remember to turn on the peripheral clock...  If not, you may be up till 3am debugging... */
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
	LED_Config.GPIO_Pin = GPIO_Pin_12 | GPIO_Pin_13| GPIO_Pin_14| GPIO_Pin_15;
	LED_Config.GPIO_Mode = GPIO_Mode_OUT;
	LED_Config.GPIO_OType = GPIO_OType_PP;
	LED_Config.GPIO_Speed = GPIO_Speed_25MHz;
	LED_Config.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_Init(GPIOD, &LED_Config);



	/* Setup SysTick or CROD! */
	if (SysTick_Config(SystemCoreClock / 1000))
	{
		ColorfulRingOfDeath();
	}


	/* Setup USB */
	USBD_Init(&USB_OTG_dev,
	            USB_OTG_FS_CORE_ID,
	            &USR_desc,
	            &USBD_CDC_cb,
	            &USR_cb);

	return;
}

/*
 * Call this to indicate a failure.  Blinks the STM32F4 discovery LEDs
 * in sequence.  At 168Mhz, the blinking will be very fast - about 5 Hz.
 * Keep that in mind when debugging, knowing the clock speed might help
 * with debugging.
 */
void ColorfulRingOfDeath(void)
{
	uint16_t ring = 1;
	while (1)
	{
		uint32_t count = 0;
		while (count++ < 500000);

		GPIOD->BSRRH = (ring << 12);
		ring = ring << 1;
		if (ring >= 1<<4)
		{
			ring = 1;
		}
		GPIOD->BSRRL = (ring << 12);
	}
}

/*
 * Interrupt Handlers
 */



void NMI_Handler(void)       {}
void HardFault_Handler(void) { ColorfulRingOfDeath(); }
void MemManage_Handler(void) { ColorfulRingOfDeath(); }
void BusFault_Handler(void)  { ColorfulRingOfDeath(); }
void UsageFault_Handler(void){ ColorfulRingOfDeath(); }
void SVC_Handler(void)       {}
void DebugMon_Handler(void)  {}
void PendSV_Handler(void)    {}

void OTG_FS_IRQHandler(void)
{
  USBD_OTG_ISR_Handler (&USB_OTG_dev);
}

void OTG_FS_WKUP_IRQHandler(void)
{
  if(USB_OTG_dev.cfg.low_power)
  {
    *(uint32_t *)(0xE000ED10) &= 0xFFFFFFF9 ;
    SystemInit();
    USB_OTG_UngateClock(&USB_OTG_dev);
  }
  EXTI_ClearITPendingBit(EXTI_Line18);
}
