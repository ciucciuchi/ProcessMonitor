namespace Monitor
{
    public class ArgumentsValidator
    {
        public bool ValidateArguments(string[] args)
        {
            if (args.Length != 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
