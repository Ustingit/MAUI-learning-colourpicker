namespace ColorPicker;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
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
	}

	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		var red = sliderRed.Value;
		var green = sliderGreen.Value;
		var blue = sliderBlue.Value;

		Color color = Color.FromRgb(red, green, blue);

		SetColor(color);
	}

	private void SetColor(Color color)
	{
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		lblHex.Text = color.ToHex();
	}
}

