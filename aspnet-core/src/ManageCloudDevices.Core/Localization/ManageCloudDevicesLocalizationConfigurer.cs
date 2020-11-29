using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ManageCloudDevices.Localization
{
    public static class ManageCloudDevicesLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ManageCloudDevicesConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ManageCloudDevicesLocalizationConfigurer).GetAssembly(),
                        "ManageCloudDevices.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
