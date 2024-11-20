using System.ComponentModel.DataAnnotations;

namespace WebMVCCourse.Attributes
{
    public class FirstCharUpperCaseAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string s = value.ToString();
            return s.Length >= 1 && char.IsUpper(s[0]);
        }
    }
}
