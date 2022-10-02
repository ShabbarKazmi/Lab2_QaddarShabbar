

namespace Lab2_QaddarShabbar;

public static class MauiProgram
{
   /**
    * 
    * Authors : Qaddar Isse, Shabbar Kazmi
    * Date 9/29/2022
    * Description : Lab2 ; a program which allows user to add,edit and delete crossword puzzle entries
    * Bugs: Everything seems to be working, except the UI have minor difference from the handout 
    * Reflection: Since .net Maui is new it has some issues with andoid emulation which make it harder to debug
    *			 We realized that in order to properly debug this program we need to emulate a windows window instead of 
    *			 using The android emulator.
    *			 
    *			 
    */
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
