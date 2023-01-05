using AbpSevenDemo.Maui.ViewModels;

namespace AbpSevenDemo.Maui.Extensions;

[ContentProperty(nameof(Text))]
public class TranslateExtension : IMarkupExtension<BindingBase>
{
    public string Text { get; set; } = string.Empty;

    public string? StringFormat { get; set; }


    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        var localizationResourceManager = serviceProvider.GetRequiredService<IRootObjectProvider>()
            .RootObject.As<BindableObject>()
            .BindingContext.As<AbpSevenDemoViewModelBase>()
            .L; ;        
        
        var binding = new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Text}]",
            Source = localizationResourceManager,
            StringFormat = StringFormat
        };
        return binding;
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
