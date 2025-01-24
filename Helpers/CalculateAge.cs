namespace Actors_RestAPI.Helpers
{
    public static class CalculateAge
    {
        public static int Calculate(string dateString)
        {

            if (string.IsNullOrWhiteSpace(dateString))
            {
                return 0;
            }

            if (!DateTime.TryParse(dateString, out DateTime birthDate))
            {
                throw new FormatException($"El formato de la fecha '{dateString}' no es válido.");
            }

            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (today < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}