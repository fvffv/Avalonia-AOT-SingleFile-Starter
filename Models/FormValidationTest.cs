using CommunityToolkit.Mvvm.ComponentModel;
using FluentValidation;
using FluentValidation.Results;

namespace avaloniaAotTemplate.Models;

public class FormValidationTest
{
    
}
public partial class UserRegInfoModel:ObservableObject
{
    [ObservableProperty]
    private string _userName;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _code;

    private UserRegInfoValidator val = new ();
 
    /// <summary>
    /// 获取表单验证对象 AOT安全   之后通过
    /// validationResult.IsValid验证是否通过表单
    /// validationResult.Errors.First().ErrorMessage获取错误信息
    /// </summary>
    /// <returns></returns>
    public ValidationResult GetValidationResult()
    {
        return val.Validate(this);
    }

   
}
public class UserRegInfoValidator : AbstractValidator<UserRegInfoModel>
{
    public UserRegInfoValidator()
    {
        // 用户名规则
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("用户名不能为空")
            .MinimumLength(3).WithMessage("用户名至少需要 3 个字符")
            .MaximumLength(20).WithMessage("用户名不能超过 20 个字符");

        // 密码规则
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("密码不能为空")
            .MinimumLength(6).WithMessage("密码至少需要 6 个字符");

        // 邮箱规则
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("邮箱不能为空")
            .EmailAddress().WithMessage("请输入正确的邮箱格式");

        // 验证码规则 
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("验证码不能为空");

    }
}