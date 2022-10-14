using CommunityToolkit.Maui.Alerts;

namespace ColorPicker;

public partial class MainPage : ContentPage
{
	bool isRandom;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void ImageBtn_Clicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(hexValue);

		var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
	 	await toast.Show();
	}

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		isRandom = true;

		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0, 265),
			random.Next(0, 265),
			random.Next(0, 265)
			);

		SetColor(color);

		sliderRed.Value = color.Red;
		sliderGreen.Value = color.Green;
		sliderBlue.Value = color.Blue;

		isRandom = false;
	}

	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!isRandom)
		{
			var red = sliderRed.Value;
			var green = sliderGreen.Value;
			var blue = sliderBlue.Value;

			Color color = Color.FromRgb(red, green, blue);

			SetColor(color);
		}
	}

	private void SetColor(Color color)
	{
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		
		hexValue = color.ToHex();
		lblHex.Text = hexValue;
	}
}

