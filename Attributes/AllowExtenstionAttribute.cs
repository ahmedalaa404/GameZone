namespace GameZone.Attributes
{
    public class AllowExtenstionAttribute:ValidationAttribute
    {
        private readonly string _allowExtenstion;

        public AllowExtenstionAttribute(string allowExtenstion)
        {
            _allowExtenstion=allowExtenstion;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile file=value as IFormFile;
            if(file != null) 
            {
                var Extenstion = Path.GetExtension(file.FileName);

                var IsAllow = _allowExtenstion.Split(',').Contains(Extenstion, StringComparer.OrdinalIgnoreCase); // return book if have the Extension 

                if (!IsAllow)
                {
                    return new ValidationResult($"Onely {_allowExtenstion}  are allowed");
                }
            }
            return ValidationResult.Success;
        }

    }
}
