using ServicoAssociadoWeb.Enums;

namespace ServicoAssociadoWeb.Services
{
    public class CommonServices
    {
        public static string ShowAlert(Alerts obj, string message)
        {
            string alertDiv = null;

            switch (obj)
            {
                case Alerts.Success:
                    alertDiv = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>&times;</button><strong></ strong > " + message + "</a></div>";
                    break;
                case Alerts.Danger:
                    alertDiv = "<div class='alert alert-danger alert-dismissible' id='alert'><button type='button' class='close' data-dismiss='alert'>&times;</button><strong></ strong > " + message + "</a></div>";
                    break;
                case Alerts.Info:
                    alertDiv = "<div class='alert alert-info alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>&times;</button><strong></ strong > " + message + "</a></div>";
                    break;
                case Alerts.Warning:
                    alertDiv = "<div class='alert alert-warning alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>&times;</button><strong></strong> " + message + "</a></div>";
                    break;
            }

            return alertDiv;
        }
    }
}
