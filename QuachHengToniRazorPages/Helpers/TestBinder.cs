using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace QuachHengToniRazorPages.Helpers
{
    public class TestBinder : IModelBinder
    {
        private readonly ILogger<TestBinder> logger;

        public TestBinder(ILogger<TestBinder> logger)
        {
            this.logger = logger;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            string modelName = bindingContext.ModelName;

            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            var capitalizedValue = value.ToUpper();

            if (capitalizedValue.Contains("XXX"))
            {
                bindingContext.ModelState.TryAddModelError(modelName, "Cannot contain this pattern xxx.");

                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(capitalizedValue.Trim());
            return Task.CompletedTask;
        }
    }
}
