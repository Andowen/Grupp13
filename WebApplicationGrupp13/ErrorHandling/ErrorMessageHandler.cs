using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationGrupp13.ErrorHandling {
    public static class ErrorMessageHandler {
        public const string SQLInsertError = "Ett fel inträffade när data skickades till databasen. Felkod: ";
        public const string SQLExtractError = "Ett fel inträffade när data hämtades från databasen. Felkod: ";
        public const string SQLError = "Ett fel inträffade i databasen. Felmeddelande: ";
       
        



        public const string EmptyTextField = "Fältet får inte lämnas tomt.";

        public static string GetErrorMessage(Exception ex) {
            
            string errorMessage = SQLError + ex.Message;

            return errorMessage;
        }


        

        






























    }
}