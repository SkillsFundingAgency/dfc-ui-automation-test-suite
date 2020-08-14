We could not find a data exchange file at the path System.Configuration.ConfigurationErrorsException: SpecFlow configuration error ---> System.Xml.XmlException: Data at the root level is invalid. Line 1, position 1.

Please open an issue at https://github.com/techtalk/SpecFlow/issues/
Complete output: 
System.Configuration.ConfigurationErrorsException: SpecFlow configuration error ---> System.Xml.XmlException: Data at the root level is invalid. Line 1, position 1.
   at System.Xml.XmlTextReaderImpl.Throw(Exception e)
   at System.Xml.XmlTextReaderImpl.ParseRootLevelWhitespace()
   at System.Xml.XmlTextReaderImpl.ParseDocumentContent()
   at System.Configuration.ConfigurationSection.DeserializeSection(XmlReader reader)
   at TechTalk.SpecFlow.Configuration.ConfigurationSectionHandler.CreateFromXml(String xmlContent)
   at TechTalk.SpecFlow.Generator.Configuration.GeneratorConfigurationProvider.GetPlugins(SpecFlowConfigurationHolder configurationHolder)
   --- End of inner exception stack trace ---
   at TechTalk.SpecFlow.Generator.Configuration.GeneratorConfigurationProvider.GetPlugins(SpecFlowConfigurationHolder configurationHolder)
   at TechTalk.SpecFlow.Generator.GeneratorContainerBuilder.LoadPlugins(ObjectContainer container, IGeneratorConfigurationProvider configurationProvider, SpecFlowConfigurationHolder configurationHolder)
   at TechTalk.SpecFlow.Generator.GeneratorContainerBuilder.CreateContainer(SpecFlowConfigurationHolder configurationHolder, ProjectSettings projectSettings)
   at TechTalk.SpecFlow.Generator.TestGeneratorFactory.CreateGenerator(ProjectSettings projectSettings)
   at TechTalk.SpecFlow.VisualStudio.CodeBehindGenerator.Actions.GenerateTestFileAction.GenerateTestFile(GenerateTestFileParameters opts)



Command: C:\USERS\KADIR\APPDATA\LOCAL\MICROSOFT\VISUALSTUDIO\16.0_120D678D\EXTENSIONS\SYVLH42A.2HM\TechTalk.SpecFlow.VisualStudio.CodeBehindGenerator.exe
Parameters: GenerateTestFile --featurefile C:\Users\kadir\AppData\Local\Temp\tmp75CD.tmp --outputdirectory C:\Users\kadir\AppData\Local\Temp --projectsettingsfile C:\Users\kadir\AppData\Local\Temp\tmp75CC.tmp
Working Directory: 
