﻿#region License
// Copyright (c) Jeremy Skinner (http://www.jeremyskinner.co.uk)
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
// 
// http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
// 
// The latest version of this file can be found at https://github.com/jeremyskinner/FluentValidation
#endregion
namespace FluentValidation.AspNetCore {
    using Internal;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Resources;
    using Validators;

    internal class MaxLengthClientValidator : AbstractComparisonClientValidator<LessThanOrEqualValidator> {
		protected override object MinValue
		{
			get { return null; }
		}

		protected override object MaxValue
		{
			get { return AbstractComparisonValidator.ValueToCompare; }
		}

		public MaxLengthClientValidator(PropertyRule rule, IPropertyValidator validator)
            : base(rule, validator) {
		}

		public override void AddValidation(ClientModelValidationContext context) {
			if (MaxValue != null) {
				MergeAttribute(context.Attributes, "data-val", "true");
				MergeAttribute(context.Attributes, "data-val-minlength", GetErrorMessage(context));
				MergeAttribute(context.Attributes, "data-val-minlength-max", MaxValue.ToString());
			}
		}

	    protected override string GetDefaultMessage() {
			return Messages.lessthanorequal_error;
		}
    }
}