using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.ValidatorCustom
{
    public class TelefonoValidator: DataAnnotationsModelValidator<Validations.TelefonoAttribute>
    {
        #region Fields

        private readonly string _errorMessage;
        private string _startDate;

        #endregion Fields

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="EndDateValidator"/> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="context">The context.</param>
        /// <param name="attribute">The attribute.</param>
        public TelefonoValidator(ModelMetadata metadata, ControllerContext context, Validations.TelefonoAttribute attribute)
            : base(metadata, context, attribute)
        {
            this._errorMessage = attribute.ErrorMessage;
            //_startDate = attribute._startdate;
        }

        #endregion Ctors

        #region Methods

        /// <summary>
        /// Retrieves a collection of client validation rules.
        /// </summary>
        /// <returns>A collection of client validation rules.</returns>
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "telefonovalidator",
                ErrorMessage = _errorMessage,
            };
            //rule.ValidationParameters.Add(new KeyValuePair<string, object>("startdate", _startDate));
            return new[] { rule };
        }

        #endregion Methods
    }
}