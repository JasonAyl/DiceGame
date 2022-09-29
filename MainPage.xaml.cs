using Plugin.Maui.Audio;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private readonly IAudioManager audioManager;
    Random rnd = new Random();
	int numrolled = 0;
    bool flashon = true;
    int secondsToVibrate = 1;



    private void ToggleShake()
    {
        if (Accelerometer.Default.IsSupported)
        {
            if (!Accelerometer.Default.IsMonitoring)
            {
                // Turn on compass
                Accelerometer.Default.ShakeDetected += Accelerometer_ShakeDetected;
                Accelerometer.Default.Start(SensorSpeed.Game);
            }
            else
            {
                // Turn off compass
                Accelerometer.Default.Stop();
                Accelerometer.Default.ShakeDetected -= Accelerometer_ShakeDetected;
            }
        }
    }

    private async void Accelerometer_ShakeDetected(object sender, EventArgs e)
    {
        numrolled = rnd.Next(1, 7);
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("diceroll.wav"));
        player.Play();
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

        Vibration.Default.Vibrate(vibrationLength);
        async void Speak()
        {
            await TextToSpeech.Default.SpeakAsync("You rolled a " + numrolled);
        }

        Thread.Sleep(1000);


        RollBtn.Text = $"You rolled a {numrolled}";
        if (numrolled == 1)
        {
            diceim.Source = "onedie.svg";
            Speak();
            flash();
        }
        else if (numrolled == 2)
        {
            diceim.Source = "twodie.svg";
            Speak();
            flash();
            flash();
        }
        else if (numrolled == 3)
        {
            diceim.Source = "threedie.svg";
            Speak();
            flash();
            flash();
            flash();
        }
        else if (numrolled == 4)
        {
            diceim.Source = "fourdie.svg";
            Speak();
            flash();
            flash();
            flash();
            flash();
        }
        else if (numrolled == 5)

        {
            diceim.Source = "fivedie.svg";
            Speak();
            flash();
            flash();
            flash();
            flash();
            flash();
        }

        else if (numrolled == 6)
        {
            diceim.Source = "sixdie.svg";
            Speak();
            flash();
            flash();
            flash();
            flash();
            flash();
            flash();
        }

        SemanticScreenReader.Announce(RollBtn.Text);
    }

    public MainPage(IAudioManager audioManager)
    {
        InitializeComponent();
        ToggleShake();
        this.audioManager = audioManager;
        
    }   
	public object flash()
	{
			Flashlight.Default.TurnOnAsync();
			Flashlight.Default.TurnOffAsync();
		return flashon;
	}

    
    public async void OnCounterClicked(object sender, EventArgs e)
	{
		numrolled = rnd.Next(1, 7);
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("diceroll.wav"));
        player.Play();
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

        Vibration.Default.Vibrate(vibrationLength);
        async void Speak()
        {
            await TextToSpeech.Default.SpeakAsync("You rolled a " + numrolled);
        }

        Thread.Sleep(1000);


        RollBtn.Text = $"You rolled a {numrolled}";
		if (numrolled == 1)
		{
            diceim.Source = "onedie.svg";
            Speak();
            flash();
        }
		else if (numrolled == 2)
        {
            diceim.Source = "twodie.svg";
            Speak();
            flash();
			flash();
        }
        else if (numrolled == 3)
        {
            diceim.Source = "threedie.svg";
            Speak();
            flash();
			flash();
			flash();
        }
        else if (numrolled == 4)
        {
            diceim.Source = "fourdie.svg";
            Speak();
            flash();
			flash();
			flash();
			flash();
        }
        else if(numrolled == 5)

        {
            diceim.Source = "fivedie.svg";
            Speak();
            flash();
            flash();
            flash();
            flash();
            flash();
        }

        else if (numrolled == 6)
        {
            diceim.Source = "sixdie.svg";
            Speak();
            flash();
            flash();
            flash();
            flash();
            flash();
            flash();
        }

        SemanticScreenReader.Announce(RollBtn.Text);
	}
}

