namespace GameZone.Attributes
{
    public class MaxFileSizeAttribute:ValidationAttribute
    {
        private readonly int  MaxSize;

        public MaxFileSizeAttribute(int Max)
        {
            MaxSize = Max;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;
            if (file.Length> MaxSize)
            {
                    return new ValidationResult($"Max Allowed Sized is  {MaxSize/(1024*1024)} Mb");
            }
            return ValidationResult.Success;
        }
    }
}
