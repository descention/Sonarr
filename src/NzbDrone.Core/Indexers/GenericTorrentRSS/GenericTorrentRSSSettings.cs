using System;
using FluentValidation;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.ThingiProvider;
using NzbDrone.Core.Validation;

namespace NzbDrone.Core.Indexers.Eztv
{
    public class GenericTorrentRSSSettingsValidator : AbstractValidator<GenericTorrentRSSSettings>
    {
        public GenericTorrentRSSSettingsValidator()
        {
            RuleFor(c => c.BaseUrl).ValidRootUrl();
        }
    }

    public class GenericTorrentRSSSettings : IProviderConfig
    {
        private static readonly GenericTorrentRSSSettingsValidator Validator = new GenericTorrentRSSSettingsValidator();

        public GenericTorrentRSSSettings()
        {
            BaseUrl = "";
        }

        [FieldDefinition(0, Label = "Website URL", HelpText = "Enter to URL to a compatible RSS feed")]
        public String BaseUrl { get; set; }

        public NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }
}