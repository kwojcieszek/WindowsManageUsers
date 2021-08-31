namespace WindowsManageUsers
{
    public class Password
    {
        // Generate a password that meets the reuirements.
        public string RandomPassword()
        {
            const string LOWER = "abcdefghijklmnopqrstuvwxyz";
            const string UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMBER = "0123456789";
            const string SPECIAL = @"!@#$%";

            int max_chars = 10;
            int num_chars = Crypto.RandomInteger(max_chars, max_chars);

            // Satisfy requirements.
            string password = "";

            for (int i = 0; i < max_chars; i++)
            {
                password += RandomChar(LOWER);
                password += RandomChar(UPPER);
                password += RandomChar(NUMBER);
                password += RandomChar(SPECIAL);
            }

            // Randomize (to mix up the required characters at the front).
            password = RandomizeString(password);

            return password.Substring(0, max_chars);
        }

        // Return a random character from a string.
        private string RandomChar(string str)
        {
            return str.Substring(Crypto.RandomInteger(0, str.Length - 1), 1);
        }

        // Return a random permutation of a string.
        private string RandomizeString(string str)
        {
            string result = "";
            while (str.Length > 0)
            {
                // Pick a random character.
                int i = Crypto.RandomInteger(0, str.Length - 1);
                result += str.Substring(i, 1);
                str = str.Remove(i, 1);
            }
            return result;
        }
    }
}
