using Microsoft.Maui.Devices.Sensors;

namespace P02.Views;

public partial class LocalizacaoPage : ContentPage
{
    public LocalizacaoPage()
    {
        InitializeComponent();
    }

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }

        if (status != PermissionStatus.Granted)
        {
            Resultado.Text = "Permiss�o de localiza��o negada.";
            return;
        }

        try
        {
            var location = await Geolocation.GetLocationAsync();

            if (location != null)
            {
                Resultado.Text = $"Latitude: {location.Latitude}\nLongitude: {location.Longitude}";
            }
            else
            {
                Resultado.Text = "N�o foi poss�vel obter a localiza��o.";
            }
        }
        catch (Exception ex)
        {
            Resultado.Text = $"Erro: {ex.Message}";
        }
    }
}
