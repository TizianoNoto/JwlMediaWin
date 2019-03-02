namespace JwlMediaWin.Services
{
    using JwlMediaWin.Core.Models;
    
    internal class StatusMessageGenerator
    {
        private string _previousMessage;

        public string Generate(FixerStatus results, string appName)
        {
            string result;

            if (results.ErrorIsTransitioning)
            {
                result = $"{appName} in transizione.";
            }
            else if (results.ErrorUnknown)
            {
                result = "Errore sconosciuto.";
            }
            else if (!results.FindWindowResult.JwlRunning)
            {
                result = $"{appName} non è in esecuzione.";
            }
            else if (!results.FindWindowResult.FoundMediaWindow)
            {
                result = $"Impossibile trovare finestra multimediale di {appName}.";
            }
            else if (results.FindWindowResult.IsAlreadyFixed)
            {
                result = $"Trovata finestra multimediale di {appName}. Già corretta.";
            }
            else if (results.IsFixed)
            {
                result = $"Trovata e corretta finestra multimediale di {appName}.";
            }
            else if (!results.CoreWindowFocused)
            {
                result = "Impossibile correggere – finestra principale non focalizzata.";
            }
            else
            {
                result = "Impossibile correggere – finestra principale focalizzata.";
            }

            if (result.Equals(_previousMessage))
            {
                return null;
            }
            
            _previousMessage = result;
            return result;
        }
    }
}
