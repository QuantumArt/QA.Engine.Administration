using System;
using System.Runtime.Serialization;
using System.Globalization;
using System.Collections.Generic;
/// <summary>
/// Константные ресурсы
/// </summary>
namespace QA.Engine.Administration.WebApp.Resources
{

    		#region Global
		[DataContract]
		public partial class Global
		{
							#region CommonStrings
				[DataMember]
				public CommonStrings CommonStrings
				{
					get
					{
						return new CommonStrings();
					}
					set
					{
					}
				}
				#endregion
							#region ConfirmStrings
				[DataMember]
				public ConfirmStrings ConfirmStrings
				{
					get
					{
						return new ConfirmStrings();
					}
					set
					{
					}
				}
				#endregion
							#region EnumStrings
				[DataMember]
				public EnumStrings EnumStrings
				{
					get
					{
						return new EnumStrings();
					}
					set
					{
					}
				}
				#endregion
							#region ErrorMessages
				[DataMember]
				public ErrorMessages ErrorMessages
				{
					get
					{
						return new ErrorMessages();
					}
					set
					{
					}
				}
				#endregion
							#region ValidationStrings
				[DataMember]
				public ValidationStrings ValidationStrings
				{
					get
					{
						return new ValidationStrings();
					}
					set
					{
					}
				}
				#endregion
							#region ViewModelStrings
				[DataMember]
				public ViewModelStrings ViewModelStrings
				{
					get
					{
						return new ViewModelStrings();
					}
					set
					{
					}
				}
				#endregion
					}

						#region CommonStrings
				[DataContract]
				public partial class CommonStrings
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public CommonStrings()
					{
													_strings.Add("AllName_en-us", "all");
													_strings.Add("AllTitle_en-us", "All");
													_strings.Add("BaseSiteMapItemName_en-us", "Section");
													_strings.Add("ContentVersionItemName_en-us", "Content version");
													_strings.Add("ItemRegions_en-us", "Element regions");
													_strings.Add("NotSpecifiedText_en-us", "Not specified");
													_strings.Add("VersionRegions_en-us", "Version regions");
													_strings.Add("WidgetItemName_en-us", "Widget");
													_strings.Add("AllName", "all");
													_strings.Add("AllTitle", "Все");
													_strings.Add("BaseSiteMapItemName", "Раздел");
													_strings.Add("ContentVersionItemName", "Контентная версия");
													_strings.Add("ItemRegions", "Регионы элемента");
													_strings.Add("NotSpecifiedText", "Не указано");
													_strings.Add("VersionRegions", "Регионы версий");
													_strings.Add("WidgetItemName", "Виджет");
											}

					
											    /// <summary>
							/// all
							/// </summary>
							[DataMember]
							public string AllName
							{
								get
								{
									if (_strings.ContainsKey("AllName" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AllName" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AllName"))
									{
										return _strings["AllName"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// All
							/// </summary>
							[DataMember]
							public string AllTitle
							{
								get
								{
									if (_strings.ContainsKey("AllTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AllTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AllTitle"))
									{
										return _strings["AllTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Section
							/// </summary>
							[DataMember]
							public string BaseSiteMapItemName
							{
								get
								{
									if (_strings.ContainsKey("BaseSiteMapItemName" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["BaseSiteMapItemName" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("BaseSiteMapItemName"))
									{
										return _strings["BaseSiteMapItemName"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Content version
							/// </summary>
							[DataMember]
							public string ContentVersionItemName
							{
								get
								{
									if (_strings.ContainsKey("ContentVersionItemName" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ContentVersionItemName" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ContentVersionItemName"))
									{
										return _strings["ContentVersionItemName"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Element regions
							/// </summary>
							[DataMember]
							public string ItemRegions
							{
								get
								{
									if (_strings.ContainsKey("ItemRegions" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ItemRegions" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ItemRegions"))
									{
										return _strings["ItemRegions"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Not specified
							/// </summary>
							[DataMember]
							public string NotSpecifiedText
							{
								get
								{
									if (_strings.ContainsKey("NotSpecifiedText" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NotSpecifiedText" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NotSpecifiedText"))
									{
										return _strings["NotSpecifiedText"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Version regions
							/// </summary>
							[DataMember]
							public string VersionRegions
							{
								get
								{
									if (_strings.ContainsKey("VersionRegions" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["VersionRegions" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("VersionRegions"))
									{
										return _strings["VersionRegions"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Widget
							/// </summary>
							[DataMember]
							public string WidgetItemName
							{
								get
								{
									if (_strings.ContainsKey("WidgetItemName" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["WidgetItemName" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("WidgetItemName"))
									{
										return _strings["WidgetItemName"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region ConfirmStrings
				[DataContract]
				public partial class ConfirmStrings
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public ConfirmStrings()
					{
													_strings.Add("Message_en-us", "Are you sure? Continue?");
													_strings.Add("NoButtonText_en-us", "No");
													_strings.Add("Title_en-us", "Confirmation");
													_strings.Add("YesButtonText_en-us", "Yes");
													_strings.Add("Message", "Вы уверены? Продолжить?");
													_strings.Add("NoButtonText", "Нет");
													_strings.Add("Title", "Подтверждение действия");
													_strings.Add("YesButtonText", "Да");
											}

					
											    /// <summary>
							/// Are you sure? Continue?
							/// </summary>
							[DataMember]
							public string Message
							{
								get
								{
									if (_strings.ContainsKey("Message" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["Message" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("Message"))
									{
										return _strings["Message"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// No
							/// </summary>
							[DataMember]
							public string NoButtonText
							{
								get
								{
									if (_strings.ContainsKey("NoButtonText" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NoButtonText" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NoButtonText"))
									{
										return _strings["NoButtonText"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Confirmation
							/// </summary>
							[DataMember]
							public string Title
							{
								get
								{
									if (_strings.ContainsKey("Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("Title"))
									{
										return _strings["Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Yes
							/// </summary>
							[DataMember]
							public string YesButtonText
							{
								get
								{
									if (_strings.ContainsKey("YesButtonText" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["YesButtonText" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("YesButtonText"))
									{
										return _strings["YesButtonText"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region EnumStrings
				[DataContract]
				public partial class EnumStrings
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public EnumStrings()
					{
													_strings.Add("ContentVersionOperations_Delete_en-us", "Remove content versions");
													_strings.Add("ContentVersionOperations_Move_en-us", "Move to another version");
													_strings.Add("VersionTypes_Content_en-us", "Content");
													_strings.Add("VersionTypes_Structural_en-us", "Structural");
													_strings.Add("ContentVersionOperations_Delete", "Удалить контентные версии");
													_strings.Add("ContentVersionOperations_Move", "Перенести на другую версию");
													_strings.Add("VersionTypes_Content", "Контентная");
													_strings.Add("VersionTypes_Structural", "Структурная");
											}

					
											    /// <summary>
							/// Remove content versions
							/// </summary>
							[DataMember]
							public string ContentVersionOperations_Delete
							{
								get
								{
									if (_strings.ContainsKey("ContentVersionOperations_Delete" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ContentVersionOperations_Delete" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ContentVersionOperations_Delete"))
									{
										return _strings["ContentVersionOperations_Delete"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Move to another version
							/// </summary>
							[DataMember]
							public string ContentVersionOperations_Move
							{
								get
								{
									if (_strings.ContainsKey("ContentVersionOperations_Move" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ContentVersionOperations_Move" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ContentVersionOperations_Move"))
									{
										return _strings["ContentVersionOperations_Move"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Content
							/// </summary>
							[DataMember]
							public string VersionTypes_Content
							{
								get
								{
									if (_strings.ContainsKey("VersionTypes_Content" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["VersionTypes_Content" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("VersionTypes_Content"))
									{
										return _strings["VersionTypes_Content"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Structural
							/// </summary>
							[DataMember]
							public string VersionTypes_Structural
							{
								get
								{
									if (_strings.ContainsKey("VersionTypes_Structural" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["VersionTypes_Structural" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("VersionTypes_Structural"))
									{
										return _strings["VersionTypes_Structural"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region ErrorMessages
				[DataContract]
				public partial class ErrorMessages
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public ErrorMessages()
					{
													_strings.Add("ErrorConfigurationMessage_en-us", "Invalid configuration file or the configuration is not found (name = {0}).");
													_strings.Add("InternalErrorMessage_en-us", "Internal error.");
													_strings.Add("LogicErrorMessage_en-us", "Functionality is not available.");
													_strings.Add("QpContentScriptGenerationErrorMessage_en-us", "Generation script error for contents.");
													_strings.Add("QpCultureScriptGenerationErrorMessage_en-us", "Generation script error for cultures.");
													_strings.Add("UnknowErrorMessage_en-us", "Unknow error.");
													_strings.Add("ErrorConfigurationMessage", "Неверный файл конфигурации или конфигурация не найдена (name = {0}).");
													_strings.Add("InternalErrorMessage", "Внутренняя ошибка.");
													_strings.Add("LogicErrorMessage", "Функционал недоступен.");
													_strings.Add("QpContentScriptGenerationErrorMessage", "Ошибка генерации скрипта для контентов.");
													_strings.Add("QpCultureScriptGenerationErrorMessage", "Ошибка генерации скрипта для культур.");
													_strings.Add("UnknowErrorMessage", "Неизвестная ошибка.");
											}

					
											    /// <summary>
							/// Invalid configuration file or the configuration is not found (name = {0}).
							/// </summary>
							[DataMember]
							public string ErrorConfigurationMessage
							{
								get
								{
									if (_strings.ContainsKey("ErrorConfigurationMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ErrorConfigurationMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ErrorConfigurationMessage"))
									{
										return _strings["ErrorConfigurationMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Internal error.
							/// </summary>
							[DataMember]
							public string InternalErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("InternalErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["InternalErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("InternalErrorMessage"))
									{
										return _strings["InternalErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Functionality is not available.
							/// </summary>
							[DataMember]
							public string LogicErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("LogicErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["LogicErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("LogicErrorMessage"))
									{
										return _strings["LogicErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Generation script error for contents.
							/// </summary>
							[DataMember]
							public string QpContentScriptGenerationErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("QpContentScriptGenerationErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["QpContentScriptGenerationErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("QpContentScriptGenerationErrorMessage"))
									{
										return _strings["QpContentScriptGenerationErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Generation script error for cultures.
							/// </summary>
							[DataMember]
							public string QpCultureScriptGenerationErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("QpCultureScriptGenerationErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["QpCultureScriptGenerationErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("QpCultureScriptGenerationErrorMessage"))
									{
										return _strings["QpCultureScriptGenerationErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Unknow error.
							/// </summary>
							[DataMember]
							public string UnknowErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("UnknowErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["UnknowErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("UnknowErrorMessage"))
									{
										return _strings["UnknowErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region ValidationStrings
				[DataContract]
				public partial class ValidationStrings
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public ValidationStrings()
					{
													_strings.Add("MinErrorMessage_en-us", "Value must be specified");
													_strings.Add("PatternErrorMessage_en-us", "Field value does not match the pattern");
													_strings.Add("RequiredErrorMessage_en-us", "Value must be specified");
													_strings.Add("RequiredIfErrorMessage_en-us", "Value must be specified");
													_strings.Add("MinErrorMessage", "Необходимо указать значение");
													_strings.Add("PatternErrorMessage", "Значение поля не соответствует шаблону");
													_strings.Add("RequiredErrorMessage", "Необходимо указать значение");
													_strings.Add("RequiredIfErrorMessage", "Необходимо указать значение");
											}

					
											    /// <summary>
							/// Value must be specified
							/// </summary>
							[DataMember]
							public string MinErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("MinErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["MinErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("MinErrorMessage"))
									{
										return _strings["MinErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Field value does not match the pattern
							/// </summary>
							[DataMember]
							public string PatternErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("PatternErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["PatternErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("PatternErrorMessage"))
									{
										return _strings["PatternErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Value must be specified
							/// </summary>
							[DataMember]
							public string RequiredErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("RequiredErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RequiredErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RequiredErrorMessage"))
									{
										return _strings["RequiredErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Value must be specified
							/// </summary>
							[DataMember]
							public string RequiredIfErrorMessage
							{
								get
								{
									if (_strings.ContainsKey("RequiredIfErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RequiredIfErrorMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RequiredIfErrorMessage"))
									{
										return _strings["RequiredIfErrorMessage"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region ViewModelStrings
				[DataContract]
				public partial class ViewModelStrings
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public ViewModelStrings()
					{
													_strings.Add("AddSiteMapViewModel_Culture_en-us", "Culture");
													_strings.Add("AddSiteMapViewModel_DiscriminatorId_Required_en-us", "Field value must be specified");
													_strings.Add("AddSiteMapViewModel_ElementType_en-us", "Element type");
													_strings.Add("AddSiteMapViewModel_Id_en-us", "Id");
													_strings.Add("AddSiteMapViewModel_InSitemap_en-us", "View in the site map");
													_strings.Add("AddSiteMapViewModel_Name_en-us", "Name");
													_strings.Add("AddSiteMapViewModel_Name_Pattern_en-us", "Invalid characters in the name");
													_strings.Add("AddSiteMapViewModel_Name_Required_en-us", "Field value must be specified");
													_strings.Add("AddSiteMapViewModel_Name_StringLength_en-us", "Max string length must be {1}");
													_strings.Add("AddSiteMapViewModel_State_en-us", "Status");
													_strings.Add("AddSiteMapViewModel_Title_en-us", "Title");
													_strings.Add("AddSiteMapViewModel_Title_Required_en-us", "Field value must be specified");
													_strings.Add("AddSiteMapViewModel_Title_StringLength_en-us", "Max string length must be {1}");
													_strings.Add("AddSiteMapViewModel_Type_en-us", "Page type");
													_strings.Add("AddSiteMapViewModel_Visible_en-us", "View in navigation");
													_strings.Add("ContentVersionOperation_Title_en-us", "Action on content versions");
													_strings.Add("DeleteSiteMapViewModel_ContentVersionId_RequiredIf_en-us", "Field value must be specified");
													_strings.Add("DeleteVersions_Title_en-us", "Remove versions");
													_strings.Add("RestoreChildren_Title_en-us", "Restore children");
													_strings.Add("RestoreContentVersions_Title_en-us", "Restore content versions");
													_strings.Add("RestoreVersions_Title_en-us", "Restore versions");
													_strings.Add("RestoreWidgets_Title_en-us", "Restore widgets");
													_strings.Add("VersionToReplace_Title_en-us", "Version to replace");
													_strings.Add("VersionType_Title_en-us", "Version type");
													_strings.Add("AddSiteMapViewModel_Culture", "Языковая культура");
													_strings.Add("AddSiteMapViewModel_DiscriminatorId_Required", "Заполните это поле");
													_strings.Add("AddSiteMapViewModel_ElementType", "Тип элемента");
													_strings.Add("AddSiteMapViewModel_Id", "Ид.");
													_strings.Add("AddSiteMapViewModel_InSitemap", "Отображать на карте сайта");
													_strings.Add("AddSiteMapViewModel_Name", "Название");
													_strings.Add("AddSiteMapViewModel_Name_Pattern", "Недопустимые символы в названии");
													_strings.Add("AddSiteMapViewModel_Name_Required", "Заполните это поле");
													_strings.Add("AddSiteMapViewModel_Name_StringLength", "Максимальная длина строки {1}");
													_strings.Add("AddSiteMapViewModel_State", "Статус статьи");
													_strings.Add("AddSiteMapViewModel_Title", "Заголовок");
													_strings.Add("AddSiteMapViewModel_Title_Required", "Заполните это поле");
													_strings.Add("AddSiteMapViewModel_Title_StringLength", "Максимальная длина строки {1}");
													_strings.Add("AddSiteMapViewModel_Type", "Тип страницы");
													_strings.Add("AddSiteMapViewModel_Visible", "Отображать в навигации");
													_strings.Add("ContentVersionOperation_Title", "Действие над контентными версиями");
													_strings.Add("DeleteSiteMapViewModel_ContentVersionId_RequiredIf", "Заполните это поле");
													_strings.Add("DeleteVersions_Title", "Удалить версии");
													_strings.Add("RestoreChildren_Title", "Восстановить подчиненные");
													_strings.Add("RestoreContentVersions_Title", "Восстановить контентные версии");
													_strings.Add("RestoreVersions_Title", "Восстановить версии");
													_strings.Add("RestoreWidgets_Title", "Восстановить виджеты");
													_strings.Add("VersionToReplace_Title", "Версия для замены");
													_strings.Add("VersionType_Title", "Тип версии");
											}

					
											    /// <summary>
							/// Culture
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Culture
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Culture" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Culture" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Culture"))
									{
										return _strings["AddSiteMapViewModel_Culture"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Field value must be specified
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_DiscriminatorId_Required
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_DiscriminatorId_Required" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_DiscriminatorId_Required" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_DiscriminatorId_Required"))
									{
										return _strings["AddSiteMapViewModel_DiscriminatorId_Required"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Element type
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_ElementType
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_ElementType" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_ElementType" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_ElementType"))
									{
										return _strings["AddSiteMapViewModel_ElementType"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Id
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Id
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Id" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Id" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Id"))
									{
										return _strings["AddSiteMapViewModel_Id"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// View in the site map
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_InSitemap
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_InSitemap" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_InSitemap" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_InSitemap"))
									{
										return _strings["AddSiteMapViewModel_InSitemap"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Name
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Name
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Name" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Name" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Name"))
									{
										return _strings["AddSiteMapViewModel_Name"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Invalid characters in the name
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Name_Pattern
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Name_Pattern" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Name_Pattern" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Name_Pattern"))
									{
										return _strings["AddSiteMapViewModel_Name_Pattern"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Field value must be specified
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Name_Required
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Name_Required" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Name_Required" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Name_Required"))
									{
										return _strings["AddSiteMapViewModel_Name_Required"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Max string length must be {1}
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Name_StringLength
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Name_StringLength" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Name_StringLength" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Name_StringLength"))
									{
										return _strings["AddSiteMapViewModel_Name_StringLength"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Status
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_State
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_State" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_State" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_State"))
									{
										return _strings["AddSiteMapViewModel_State"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Title
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Title
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Title"))
									{
										return _strings["AddSiteMapViewModel_Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Field value must be specified
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Title_Required
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Title_Required" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Title_Required" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Title_Required"))
									{
										return _strings["AddSiteMapViewModel_Title_Required"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Max string length must be {1}
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Title_StringLength
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Title_StringLength" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Title_StringLength" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Title_StringLength"))
									{
										return _strings["AddSiteMapViewModel_Title_StringLength"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Page type
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Type
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Type" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Type" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Type"))
									{
										return _strings["AddSiteMapViewModel_Type"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// View in navigation
							/// </summary>
							[DataMember]
							public string AddSiteMapViewModel_Visible
							{
								get
								{
									if (_strings.ContainsKey("AddSiteMapViewModel_Visible" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddSiteMapViewModel_Visible" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddSiteMapViewModel_Visible"))
									{
										return _strings["AddSiteMapViewModel_Visible"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Action on content versions
							/// </summary>
							[DataMember]
							public string ContentVersionOperation_Title
							{
								get
								{
									if (_strings.ContainsKey("ContentVersionOperation_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ContentVersionOperation_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ContentVersionOperation_Title"))
									{
										return _strings["ContentVersionOperation_Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Field value must be specified
							/// </summary>
							[DataMember]
							public string DeleteSiteMapViewModel_ContentVersionId_RequiredIf
							{
								get
								{
									if (_strings.ContainsKey("DeleteSiteMapViewModel_ContentVersionId_RequiredIf" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteSiteMapViewModel_ContentVersionId_RequiredIf" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteSiteMapViewModel_ContentVersionId_RequiredIf"))
									{
										return _strings["DeleteSiteMapViewModel_ContentVersionId_RequiredIf"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Remove versions
							/// </summary>
							[DataMember]
							public string DeleteVersions_Title
							{
								get
								{
									if (_strings.ContainsKey("DeleteVersions_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteVersions_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteVersions_Title"))
									{
										return _strings["DeleteVersions_Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Restore children
							/// </summary>
							[DataMember]
							public string RestoreChildren_Title
							{
								get
								{
									if (_strings.ContainsKey("RestoreChildren_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RestoreChildren_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RestoreChildren_Title"))
									{
										return _strings["RestoreChildren_Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Restore content versions
							/// </summary>
							[DataMember]
							public string RestoreContentVersions_Title
							{
								get
								{
									if (_strings.ContainsKey("RestoreContentVersions_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RestoreContentVersions_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RestoreContentVersions_Title"))
									{
										return _strings["RestoreContentVersions_Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Restore versions
							/// </summary>
							[DataMember]
							public string RestoreVersions_Title
							{
								get
								{
									if (_strings.ContainsKey("RestoreVersions_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RestoreVersions_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RestoreVersions_Title"))
									{
										return _strings["RestoreVersions_Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Restore widgets
							/// </summary>
							[DataMember]
							public string RestoreWidgets_Title
							{
								get
								{
									if (_strings.ContainsKey("RestoreWidgets_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RestoreWidgets_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RestoreWidgets_Title"))
									{
										return _strings["RestoreWidgets_Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Version to replace
							/// </summary>
							[DataMember]
							public string VersionToReplace_Title
							{
								get
								{
									if (_strings.ContainsKey("VersionToReplace_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["VersionToReplace_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("VersionToReplace_Title"))
									{
										return _strings["VersionToReplace_Title"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Version type
							/// </summary>
							[DataMember]
							public string VersionType_Title
							{
								get
								{
									if (_strings.ContainsKey("VersionType_Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["VersionType_Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("VersionType_Title"))
									{
										return _strings["VersionType_Title"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
					#endregion
    		#region Shared
		[DataContract]
		public partial class Shared
		{
							#region Actions
				[DataMember]
				public Actions Actions
				{
					get
					{
						return new Actions();
					}
					set
					{
					}
				}
				#endregion
							#region Error
				[DataMember]
				public Error Error
				{
					get
					{
						return new Error();
					}
					set
					{
					}
				}
				#endregion
							#region Menu
				[DataMember]
				public Menu Menu
				{
					get
					{
						return new Menu();
					}
					set
					{
					}
				}
				#endregion
							#region NoData
				[DataMember]
				public NoData NoData
				{
					get
					{
						return new NoData();
					}
					set
					{
					}
				}
				#endregion
					}

						#region Actions
				[DataContract]
				public partial class Actions
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Actions()
					{
													_strings.Add("AlsoText_en-us", "Also you can:");
													_strings.Add("BackText_en-us", "Back");
													_strings.Add("BackToPreviouslyPage_en-us", "to previously page");
													_strings.Add("GoToMainPage_en-us", "to homepage");
													_strings.Add("GoToText_en-us", "Go to");
													_strings.Add("AlsoText", "Также вы можете:");
													_strings.Add("BackText", "Вернуться");
													_strings.Add("BackToPreviouslyPage", "на предыдущую страницу");
													_strings.Add("GoToMainPage", "на главную страницу");
													_strings.Add("GoToText", "Перейти");
											}

					
											    /// <summary>
							/// Also you can:
							/// </summary>
							[DataMember]
							public string AlsoText
							{
								get
								{
									if (_strings.ContainsKey("AlsoText" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AlsoText" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AlsoText"))
									{
										return _strings["AlsoText"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Back
							/// </summary>
							[DataMember]
							public string BackText
							{
								get
								{
									if (_strings.ContainsKey("BackText" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["BackText" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("BackText"))
									{
										return _strings["BackText"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// to previously page
							/// </summary>
							[DataMember]
							public string BackToPreviouslyPage
							{
								get
								{
									if (_strings.ContainsKey("BackToPreviouslyPage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["BackToPreviouslyPage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("BackToPreviouslyPage"))
									{
										return _strings["BackToPreviouslyPage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// to homepage
							/// </summary>
							[DataMember]
							public string GoToMainPage
							{
								get
								{
									if (_strings.ContainsKey("GoToMainPage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["GoToMainPage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("GoToMainPage"))
									{
										return _strings["GoToMainPage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Go to
							/// </summary>
							[DataMember]
							public string GoToText
							{
								get
								{
									if (_strings.ContainsKey("GoToText" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["GoToText" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("GoToText"))
									{
										return _strings["GoToText"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Error
				[DataContract]
				public partial class Error
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Error()
					{
													_strings.Add("Text1_en-us", "Sorry, an error occurred on the server, we have all the forces working to resolve.");
													_strings.Add("Text2_en-us", "Please try reloading the page or go to the service later.");
													_strings.Add("Title_en-us", "The server encountered an error");
													_strings.Add("Text1", "Извините, на сервере возникла ошибка, мы уже всеми силами работаем над ее устранением.");
													_strings.Add("Text2", "Пожалуйста, попробуйте перезагрузить страницу или обратиться к сервису позднее.");
													_strings.Add("Title", "На сервере возникла ошибка");
											}

					
											    /// <summary>
							/// Sorry, an error occurred on the server, we have all the forces working to resolve.
							/// </summary>
							[DataMember]
							public string Text1
							{
								get
								{
									if (_strings.ContainsKey("Text1" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["Text1" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("Text1"))
									{
										return _strings["Text1"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Please try reloading the page or go to the service later.
							/// </summary>
							[DataMember]
							public string Text2
							{
								get
								{
									if (_strings.ContainsKey("Text2" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["Text2" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("Text2"))
									{
										return _strings["Text2"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// The server encountered an error
							/// </summary>
							[DataMember]
							public string Title
							{
								get
								{
									if (_strings.ContainsKey("Title" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["Title" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("Title"))
									{
										return _strings["Title"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Menu
				[DataContract]
				public partial class Menu
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Menu()
					{
													_strings.Add("IndexMenuItemTitle_en-us", "Management site map");
													_strings.Add("IndexMenuItemTitle", "Управление структурой");
											}

					
											    /// <summary>
							/// Management site map
							/// </summary>
							[DataMember]
							public string IndexMenuItemTitle
							{
								get
								{
									if (_strings.ContainsKey("IndexMenuItemTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["IndexMenuItemTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("IndexMenuItemTitle"))
									{
										return _strings["IndexMenuItemTitle"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region NoData
				[DataContract]
				public partial class NoData
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public NoData()
					{
													_strings.Add("NoDataMessage_en-us", "No data for display.");
													_strings.Add("NoDataMessage", "Нет данных для отображения.");
											}

					
											    /// <summary>
							/// No data for display.
							/// </summary>
							[DataMember]
							public string NoDataMessage
							{
								get
								{
									if (_strings.ContainsKey("NoDataMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NoDataMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NoDataMessage"))
									{
										return _strings["NoDataMessage"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
					#endregion
    		#region SiteMap
		[DataContract]
		public partial class SiteMap
		{
							#region AjaxAdd
				[DataMember]
				public AjaxAdd AjaxAdd
				{
					get
					{
						return new AjaxAdd();
					}
					set
					{
					}
				}
				#endregion
							#region AjaxDelete
				[DataMember]
				public AjaxDelete AjaxDelete
				{
					get
					{
						return new AjaxDelete();
					}
					set
					{
					}
				}
				#endregion
							#region AjaxEdit
				[DataMember]
				public AjaxEdit AjaxEdit
				{
					get
					{
						return new AjaxEdit();
					}
					set
					{
					}
				}
				#endregion
							#region AjaxMove
				[DataMember]
				public AjaxMove AjaxMove
				{
					get
					{
						return new AjaxMove();
					}
					set
					{
					}
				}
				#endregion
							#region AjaxRemove
				[DataMember]
				public AjaxRemove AjaxRemove
				{
					get
					{
						return new AjaxRemove();
					}
					set
					{
					}
				}
				#endregion
							#region AjaxRestore
				[DataMember]
				public AjaxRestore AjaxRestore
				{
					get
					{
						return new AjaxRestore();
					}
					set
					{
					}
				}
				#endregion
							#region Archive
				[DataMember]
				public Archive Archive
				{
					get
					{
						return new Archive();
					}
					set
					{
					}
				}
				#endregion
							#region ArchiveInfo
				[DataMember]
				public ArchiveInfo ArchiveInfo
				{
					get
					{
						return new ArchiveInfo();
					}
					set
					{
					}
				}
				#endregion
							#region ContentVersions
				[DataMember]
				public ContentVersions ContentVersions
				{
					get
					{
						return new ContentVersions();
					}
					set
					{
					}
				}
				#endregion
							#region Filter
				[DataMember]
				public Filter Filter
				{
					get
					{
						return new Filter();
					}
					set
					{
					}
				}
				#endregion
							#region Index
				[DataMember]
				public Index Index
				{
					get
					{
						return new Index();
					}
					set
					{
					}
				}
				#endregion
							#region Info
				[DataMember]
				public Info Info
				{
					get
					{
						return new Info();
					}
					set
					{
					}
				}
				#endregion
							#region Regions
				[DataMember]
				public Regions Regions
				{
					get
					{
						return new Regions();
					}
					set
					{
					}
				}
				#endregion
							#region Toolbar
				[DataMember]
				public Toolbar Toolbar
				{
					get
					{
						return new Toolbar();
					}
					set
					{
					}
				}
				#endregion
							#region Widgets
				[DataMember]
				public Widgets Widgets
				{
					get
					{
						return new Widgets();
					}
					set
					{
					}
				}
				#endregion
					}

						#region AjaxAdd
				[DataContract]
				public partial class AjaxAdd
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public AjaxAdd()
					{
													_strings.Add("AddButton_en-us", "Add");
													_strings.Add("AddWindowTitle_en-us", "Add section");
													_strings.Add("CancelButton_en-us", "Cancel");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("AddButton", "Добавить");
													_strings.Add("AddWindowTitle", "Добавить раздел");
													_strings.Add("CancelButton", "Отмена");
													_strings.Add("RefreshButton", "Обновить");
											}

					
											    /// <summary>
							/// Add
							/// </summary>
							[DataMember]
							public string AddButton
							{
								get
								{
									if (_strings.ContainsKey("AddButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddButton"))
									{
										return _strings["AddButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Add section
							/// </summary>
							[DataMember]
							public string AddWindowTitle
							{
								get
								{
									if (_strings.ContainsKey("AddWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddWindowTitle"))
									{
										return _strings["AddWindowTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Cancel
							/// </summary>
							[DataMember]
							public string CancelButton
							{
								get
								{
									if (_strings.ContainsKey("CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CancelButton"))
									{
										return _strings["CancelButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region AjaxDelete
				[DataContract]
				public partial class AjaxDelete
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public AjaxDelete()
					{
													_strings.Add("CancelButton_en-us", "Cancel");
													_strings.Add("DeleteButton_en-us", "Delete");
													_strings.Add("DeleteWindowTitle_en-us", "Delete section");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("CancelButton", "Отмена");
													_strings.Add("DeleteButton", "Удалить");
													_strings.Add("DeleteWindowTitle", "Удалить раздел");
													_strings.Add("RefreshButton", "Обновить");
											}

					
											    /// <summary>
							/// Cancel
							/// </summary>
							[DataMember]
							public string CancelButton
							{
								get
								{
									if (_strings.ContainsKey("CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CancelButton"))
									{
										return _strings["CancelButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Delete
							/// </summary>
							[DataMember]
							public string DeleteButton
							{
								get
								{
									if (_strings.ContainsKey("DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteButton"))
									{
										return _strings["DeleteButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Delete section
							/// </summary>
							[DataMember]
							public string DeleteWindowTitle
							{
								get
								{
									if (_strings.ContainsKey("DeleteWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteWindowTitle"))
									{
										return _strings["DeleteWindowTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region AjaxEdit
				[DataContract]
				public partial class AjaxEdit
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public AjaxEdit()
					{
													_strings.Add("CancelEditButton_en-us", "Cancel");
													_strings.Add("EditButton_en-us", "Edit");
													_strings.Add("EditWindowTitle_en-us", "Edit section");
													_strings.Add("CancelEditButton", "Отмена");
													_strings.Add("EditButton", "Изменить");
													_strings.Add("EditWindowTitle", "Редактирование раздела");
											}

					
											    /// <summary>
							/// Cancel
							/// </summary>
							[DataMember]
							public string CancelEditButton
							{
								get
								{
									if (_strings.ContainsKey("CancelEditButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CancelEditButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CancelEditButton"))
									{
										return _strings["CancelEditButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Edit
							/// </summary>
							[DataMember]
							public string EditButton
							{
								get
								{
									if (_strings.ContainsKey("EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("EditButton"))
									{
										return _strings["EditButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Edit section
							/// </summary>
							[DataMember]
							public string EditWindowTitle
							{
								get
								{
									if (_strings.ContainsKey("EditWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["EditWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("EditWindowTitle"))
									{
										return _strings["EditWindowTitle"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region AjaxMove
				[DataContract]
				public partial class AjaxMove
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public AjaxMove()
					{
													_strings.Add("CancelButton_en-us", "Cancel");
													_strings.Add("CopyButton_en-us", "Copy");
													_strings.Add("MoveButton_en-us", "Move");
													_strings.Add("MoveDialogTitle_en-us", "Move options");
													_strings.Add("NoAskMore_en-us", "Do not ask (in the current session)");
													_strings.Add("CancelButton", "Отмена");
													_strings.Add("CopyButton", "Копировать");
													_strings.Add("MoveButton", "Переместить");
													_strings.Add("MoveDialogTitle", "Опции перемещения");
													_strings.Add("NoAskMore", "Больше не спрашивать (в текущей сессии)");
											}

					
											    /// <summary>
							/// Cancel
							/// </summary>
							[DataMember]
							public string CancelButton
							{
								get
								{
									if (_strings.ContainsKey("CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CancelButton"))
									{
										return _strings["CancelButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Copy
							/// </summary>
							[DataMember]
							public string CopyButton
							{
								get
								{
									if (_strings.ContainsKey("CopyButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CopyButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CopyButton"))
									{
										return _strings["CopyButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Move
							/// </summary>
							[DataMember]
							public string MoveButton
							{
								get
								{
									if (_strings.ContainsKey("MoveButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["MoveButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("MoveButton"))
									{
										return _strings["MoveButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Move options
							/// </summary>
							[DataMember]
							public string MoveDialogTitle
							{
								get
								{
									if (_strings.ContainsKey("MoveDialogTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["MoveDialogTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("MoveDialogTitle"))
									{
										return _strings["MoveDialogTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Do not ask (in the current session)
							/// </summary>
							[DataMember]
							public string NoAskMore
							{
								get
								{
									if (_strings.ContainsKey("NoAskMore" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NoAskMore" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NoAskMore"))
									{
										return _strings["NoAskMore"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region AjaxRemove
				[DataContract]
				public partial class AjaxRemove
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public AjaxRemove()
					{
													_strings.Add("CancelButton_en-us", "Cancel");
													_strings.Add("DeleteButton_en-us", "Remove");
													_strings.Add("DeleteWindowTitle_en-us", "Remove section");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("CancelButton", "Отмена");
													_strings.Add("DeleteButton", "Удалить");
													_strings.Add("DeleteWindowTitle", "Удалить раздел");
													_strings.Add("RefreshButton", "Обновить");
											}

					
											    /// <summary>
							/// Cancel
							/// </summary>
							[DataMember]
							public string CancelButton
							{
								get
								{
									if (_strings.ContainsKey("CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CancelButton"))
									{
										return _strings["CancelButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Remove
							/// </summary>
							[DataMember]
							public string DeleteButton
							{
								get
								{
									if (_strings.ContainsKey("DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteButton"))
									{
										return _strings["DeleteButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Remove section
							/// </summary>
							[DataMember]
							public string DeleteWindowTitle
							{
								get
								{
									if (_strings.ContainsKey("DeleteWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteWindowTitle"))
									{
										return _strings["DeleteWindowTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region AjaxRestore
				[DataContract]
				public partial class AjaxRestore
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public AjaxRestore()
					{
													_strings.Add("CancelButton_en-us", "Cancel");
													_strings.Add("RestoreButton_en-us", "Restore");
													_strings.Add("RestoreWindowTitle_en-us", "Restore section");
													_strings.Add("CancelButton", "Отмена");
													_strings.Add("RestoreButton", "Восстановить");
													_strings.Add("RestoreWindowTitle", "Восстановить раздел");
											}

					
											    /// <summary>
							/// Cancel
							/// </summary>
							[DataMember]
							public string CancelButton
							{
								get
								{
									if (_strings.ContainsKey("CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CancelButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CancelButton"))
									{
										return _strings["CancelButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Restore
							/// </summary>
							[DataMember]
							public string RestoreButton
							{
								get
								{
									if (_strings.ContainsKey("RestoreButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RestoreButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RestoreButton"))
									{
										return _strings["RestoreButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Restore section
							/// </summary>
							[DataMember]
							public string RestoreWindowTitle
							{
								get
								{
									if (_strings.ContainsKey("RestoreWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RestoreWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RestoreWindowTitle"))
									{
										return _strings["RestoreWindowTitle"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Archive
				[DataContract]
				public partial class Archive
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Archive()
					{
													_strings.Add("CommonTabTitle_en-us", "Common");
													_strings.Add("DeleteItem_en-us", "Delete");
													_strings.Add("NoDataMessage_en-us", "No data for dispaly");
													_strings.Add("RefreshItem_en-us", "Refresh");
													_strings.Add("RestoreItem_en-us", "Restore");
													_strings.Add("CommonTabTitle", "Общие");
													_strings.Add("DeleteItem", "Удалить");
													_strings.Add("NoDataMessage", "Нет данных для отображения.");
													_strings.Add("RefreshItem", "Обновить");
													_strings.Add("RestoreItem", "Восстановить");
											}

					
											    /// <summary>
							/// Common
							/// </summary>
							[DataMember]
							public string CommonTabTitle
							{
								get
								{
									if (_strings.ContainsKey("CommonTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CommonTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CommonTabTitle"))
									{
										return _strings["CommonTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Delete
							/// </summary>
							[DataMember]
							public string DeleteItem
							{
								get
								{
									if (_strings.ContainsKey("DeleteItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteItem"))
									{
										return _strings["DeleteItem"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// No data for dispaly
							/// </summary>
							[DataMember]
							public string NoDataMessage
							{
								get
								{
									if (_strings.ContainsKey("NoDataMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NoDataMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NoDataMessage"))
									{
										return _strings["NoDataMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshItem
							{
								get
								{
									if (_strings.ContainsKey("RefreshItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshItem"))
									{
										return _strings["RefreshItem"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Restore
							/// </summary>
							[DataMember]
							public string RestoreItem
							{
								get
								{
									if (_strings.ContainsKey("RestoreItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RestoreItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RestoreItem"))
									{
										return _strings["RestoreItem"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region ArchiveInfo
				[DataContract]
				public partial class ArchiveInfo
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public ArchiveInfo()
					{
													_strings.Add("EditButton_en-us", "Save");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("EditButton", "Сохранить");
													_strings.Add("RefreshButton", "Обновить");
											}

					
											    /// <summary>
							/// Save
							/// </summary>
							[DataMember]
							public string EditButton
							{
								get
								{
									if (_strings.ContainsKey("EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("EditButton"))
									{
										return _strings["EditButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region ContentVersions
				[DataContract]
				public partial class ContentVersions
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public ContentVersions()
					{
													_strings.Add("AddButton_en-us", "Add");
													_strings.Add("CultureColumnTitle_en-us", "Culture");
													_strings.Add("DeleteButton_en-us", "Delete");
													_strings.Add("EditButton_en-us", "Edit");
													_strings.Add("HistoryButton_en-us", "History");
													_strings.Add("IdColumnTitle_en-us", "Id");
													_strings.Add("NameColumnStatusName_en-us", "Status");
													_strings.Add("PreviewButton_en-us", "View");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("RegionTabTitle_en-us", "Regions");
													_strings.Add("SelectButton_en-us", "Select");
													_strings.Add("TitleColumnTitle_en-us", "Title");
													_strings.Add("TypeColumnTitle_en-us", "Type");
													_strings.Add("AddButton", "Добавить");
													_strings.Add("CultureColumnTitle", "Культура");
													_strings.Add("DeleteButton", "Удалить");
													_strings.Add("EditButton", "Изменить");
													_strings.Add("HistoryButton", "История");
													_strings.Add("IdColumnTitle", "Ид.");
													_strings.Add("NameColumnStatusName", "Статус");
													_strings.Add("PreviewButton", "Просмотр");
													_strings.Add("RefreshButton", "Обновить");
													_strings.Add("RegionTabTitle", "Регионы");
													_strings.Add("SelectButton", "Выбрать");
													_strings.Add("TitleColumnTitle", "Заголовок");
													_strings.Add("TypeColumnTitle", "Тип");
											}

					
											    /// <summary>
							/// Add
							/// </summary>
							[DataMember]
							public string AddButton
							{
								get
								{
									if (_strings.ContainsKey("AddButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddButton"))
									{
										return _strings["AddButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Culture
							/// </summary>
							[DataMember]
							public string CultureColumnTitle
							{
								get
								{
									if (_strings.ContainsKey("CultureColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CultureColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CultureColumnTitle"))
									{
										return _strings["CultureColumnTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Delete
							/// </summary>
							[DataMember]
							public string DeleteButton
							{
								get
								{
									if (_strings.ContainsKey("DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteButton"))
									{
										return _strings["DeleteButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Edit
							/// </summary>
							[DataMember]
							public string EditButton
							{
								get
								{
									if (_strings.ContainsKey("EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("EditButton"))
									{
										return _strings["EditButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// History
							/// </summary>
							[DataMember]
							public string HistoryButton
							{
								get
								{
									if (_strings.ContainsKey("HistoryButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["HistoryButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("HistoryButton"))
									{
										return _strings["HistoryButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Id
							/// </summary>
							[DataMember]
							public string IdColumnTitle
							{
								get
								{
									if (_strings.ContainsKey("IdColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["IdColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("IdColumnTitle"))
									{
										return _strings["IdColumnTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Status
							/// </summary>
							[DataMember]
							public string NameColumnStatusName
							{
								get
								{
									if (_strings.ContainsKey("NameColumnStatusName" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnStatusName" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnStatusName"))
									{
										return _strings["NameColumnStatusName"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// View
							/// </summary>
							[DataMember]
							public string PreviewButton
							{
								get
								{
									if (_strings.ContainsKey("PreviewButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["PreviewButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("PreviewButton"))
									{
										return _strings["PreviewButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Regions
							/// </summary>
							[DataMember]
							public string RegionTabTitle
							{
								get
								{
									if (_strings.ContainsKey("RegionTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RegionTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RegionTabTitle"))
									{
										return _strings["RegionTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Select
							/// </summary>
							[DataMember]
							public string SelectButton
							{
								get
								{
									if (_strings.ContainsKey("SelectButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["SelectButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("SelectButton"))
									{
										return _strings["SelectButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Title
							/// </summary>
							[DataMember]
							public string TitleColumnTitle
							{
								get
								{
									if (_strings.ContainsKey("TitleColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["TitleColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("TitleColumnTitle"))
									{
										return _strings["TitleColumnTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Type
							/// </summary>
							[DataMember]
							public string TypeColumnTitle
							{
								get
								{
									if (_strings.ContainsKey("TypeColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["TypeColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("TypeColumnTitle"))
									{
										return _strings["TypeColumnTitle"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Filter
				[DataContract]
				public partial class Filter
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Filter()
					{
													_strings.Add("ApplyFilterButton_en-us", "Filter");
													_strings.Add("CultureParameter_en-us", "Culture");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("RegionsParameter_en-us", "Regions");
													_strings.Add("ApplyFilterButton", "Фильтр");
													_strings.Add("CultureParameter", "Культура");
													_strings.Add("RefreshButton", "Обновить");
													_strings.Add("RegionsParameter", "Регионы");
											}

					
											    /// <summary>
							/// Filter
							/// </summary>
							[DataMember]
							public string ApplyFilterButton
							{
								get
								{
									if (_strings.ContainsKey("ApplyFilterButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ApplyFilterButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ApplyFilterButton"))
									{
										return _strings["ApplyFilterButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Culture
							/// </summary>
							[DataMember]
							public string CultureParameter
							{
								get
								{
									if (_strings.ContainsKey("CultureParameter" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CultureParameter" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CultureParameter"))
									{
										return _strings["CultureParameter"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Regions
							/// </summary>
							[DataMember]
							public string RegionsParameter
							{
								get
								{
									if (_strings.ContainsKey("RegionsParameter" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RegionsParameter" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RegionsParameter"))
									{
										return _strings["RegionsParameter"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Index
				[DataContract]
				public partial class Index
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Index()
					{
													_strings.Add("ArchiveTabTitle_en-us", "Archive");
													_strings.Add("CommonTabTitle_en-us", "Common");
													_strings.Add("ContentVersionsTabTitle_en-us", "Content versions");
													_strings.Add("NoDataMessage_en-us", "No data for display");
													_strings.Add("RegionsTabTitle_en-us", "Regions");
													_strings.Add("SiteMapTabTitle_en-us", "Site map");
													_strings.Add("SuccessfullyPublishingMessage_en-us", "Element has been successfully published");
													_strings.Add("WidgetsTabTitle_en-us", "Widgets");
													_strings.Add("ArchiveTabTitle", "Архив");
													_strings.Add("CommonTabTitle", "Общие");
													_strings.Add("ContentVersionsTabTitle", "Контентные версии");
													_strings.Add("NoDataMessage", "Нет данных для отображения.");
													_strings.Add("RegionsTabTitle", "Регионы");
													_strings.Add("SiteMapTabTitle", "Структура сайта");
													_strings.Add("SuccessfullyPublishingMessage", "Элемент успешно опубликован");
													_strings.Add("WidgetsTabTitle", "Виджеты");
											}

					
											    /// <summary>
							/// Archive
							/// </summary>
							[DataMember]
							public string ArchiveTabTitle
							{
								get
								{
									if (_strings.ContainsKey("ArchiveTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ArchiveTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ArchiveTabTitle"))
									{
										return _strings["ArchiveTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Common
							/// </summary>
							[DataMember]
							public string CommonTabTitle
							{
								get
								{
									if (_strings.ContainsKey("CommonTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["CommonTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("CommonTabTitle"))
									{
										return _strings["CommonTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Content versions
							/// </summary>
							[DataMember]
							public string ContentVersionsTabTitle
							{
								get
								{
									if (_strings.ContainsKey("ContentVersionsTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["ContentVersionsTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("ContentVersionsTabTitle"))
									{
										return _strings["ContentVersionsTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// No data for display
							/// </summary>
							[DataMember]
							public string NoDataMessage
							{
								get
								{
									if (_strings.ContainsKey("NoDataMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NoDataMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NoDataMessage"))
									{
										return _strings["NoDataMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Regions
							/// </summary>
							[DataMember]
							public string RegionsTabTitle
							{
								get
								{
									if (_strings.ContainsKey("RegionsTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RegionsTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RegionsTabTitle"))
									{
										return _strings["RegionsTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Site map
							/// </summary>
							[DataMember]
							public string SiteMapTabTitle
							{
								get
								{
									if (_strings.ContainsKey("SiteMapTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["SiteMapTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("SiteMapTabTitle"))
									{
										return _strings["SiteMapTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Element has been successfully published
							/// </summary>
							[DataMember]
							public string SuccessfullyPublishingMessage
							{
								get
								{
									if (_strings.ContainsKey("SuccessfullyPublishingMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["SuccessfullyPublishingMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("SuccessfullyPublishingMessage"))
									{
										return _strings["SuccessfullyPublishingMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Widgets
							/// </summary>
							[DataMember]
							public string WidgetsTabTitle
							{
								get
								{
									if (_strings.ContainsKey("WidgetsTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["WidgetsTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("WidgetsTabTitle"))
									{
										return _strings["WidgetsTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Info
				[DataContract]
				public partial class Info
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Info()
					{
													_strings.Add("EditButton_en-us", "Save");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("EditButton", "Сохранить");
													_strings.Add("RefreshButton", "Обновить");
											}

					
											    /// <summary>
							/// Save
							/// </summary>
							[DataMember]
							public string EditButton
							{
								get
								{
									if (_strings.ContainsKey("EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("EditButton"))
									{
										return _strings["EditButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Regions
				[DataContract]
				public partial class Regions
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Regions()
					{
													_strings.Add("AddButton_en-us", "Add");
													_strings.Add("DeleteButton_en-us", "Delete");
													_strings.Add("NameColumnAlias_en-us", "Alias");
													_strings.Add("NameColumnId_en-us", "Id");
													_strings.Add("NameColumnTitle_en-us", "Name");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("RegionTabTitle_en-us", "Regions");
													_strings.Add("AddButton", "Выбрать");
													_strings.Add("DeleteButton", "Удалить");
													_strings.Add("NameColumnAlias", "Псевдоним");
													_strings.Add("NameColumnId", "Ид.");
													_strings.Add("NameColumnTitle", "Название");
													_strings.Add("RefreshButton", "Обновить");
													_strings.Add("RegionTabTitle", "Регионы");
											}

					
											    /// <summary>
							/// Add
							/// </summary>
							[DataMember]
							public string AddButton
							{
								get
								{
									if (_strings.ContainsKey("AddButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddButton"))
									{
										return _strings["AddButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Delete
							/// </summary>
							[DataMember]
							public string DeleteButton
							{
								get
								{
									if (_strings.ContainsKey("DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteButton"))
									{
										return _strings["DeleteButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Alias
							/// </summary>
							[DataMember]
							public string NameColumnAlias
							{
								get
								{
									if (_strings.ContainsKey("NameColumnAlias" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnAlias" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnAlias"))
									{
										return _strings["NameColumnAlias"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Id
							/// </summary>
							[DataMember]
							public string NameColumnId
							{
								get
								{
									if (_strings.ContainsKey("NameColumnId" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnId" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnId"))
									{
										return _strings["NameColumnId"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Name
							/// </summary>
							[DataMember]
							public string NameColumnTitle
							{
								get
								{
									if (_strings.ContainsKey("NameColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnTitle"))
									{
										return _strings["NameColumnTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Regions
							/// </summary>
							[DataMember]
							public string RegionTabTitle
							{
								get
								{
									if (_strings.ContainsKey("RegionTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RegionTabTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RegionTabTitle"))
									{
										return _strings["RegionTabTitle"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Toolbar
				[DataContract]
				public partial class Toolbar
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Toolbar()
					{
													_strings.Add("AddChildPageItem_en-us", "Add subsection");
													_strings.Add("AddVersionPageItem_en-us", "Add version");
													_strings.Add("DeletePageItem_en-us", "Archive");
													_strings.Add("EditPageItem_en-us", "Edit");
													_strings.Add("HasItemWarningMessage_en-us", "Section with the same name already exists. Available only to create versions. Do you want to continue the creation of version?");
													_strings.Add("PreviewItem_en-us", "View");
													_strings.Add("PreviewItemVersions_en-us", "History");
													_strings.Add("PublishItem_en-us", "Publish");
													_strings.Add("RefreshItem_en-us", "Refresh");
													_strings.Add("AddChildPageItem", "Добавить подраздел");
													_strings.Add("AddVersionPageItem", "Добавить версию");
													_strings.Add("DeletePageItem", "Архивировать");
													_strings.Add("EditPageItem", "Редактировать");
													_strings.Add("HasItemWarningMessage", "Раздел с таким именем уже существует. Доступно только создание версии. Продожить создание версии?");
													_strings.Add("PreviewItem", "Просмотр");
													_strings.Add("PreviewItemVersions", "История изменений");
													_strings.Add("PublishItem", "Публиковать");
													_strings.Add("RefreshItem", "Обновить");
											}

					
											    /// <summary>
							/// Add subsection
							/// </summary>
							[DataMember]
							public string AddChildPageItem
							{
								get
								{
									if (_strings.ContainsKey("AddChildPageItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddChildPageItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddChildPageItem"))
									{
										return _strings["AddChildPageItem"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Add version
							/// </summary>
							[DataMember]
							public string AddVersionPageItem
							{
								get
								{
									if (_strings.ContainsKey("AddVersionPageItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddVersionPageItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddVersionPageItem"))
									{
										return _strings["AddVersionPageItem"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Archive
							/// </summary>
							[DataMember]
							public string DeletePageItem
							{
								get
								{
									if (_strings.ContainsKey("DeletePageItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeletePageItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeletePageItem"))
									{
										return _strings["DeletePageItem"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Edit
							/// </summary>
							[DataMember]
							public string EditPageItem
							{
								get
								{
									if (_strings.ContainsKey("EditPageItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["EditPageItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("EditPageItem"))
									{
										return _strings["EditPageItem"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Section with the same name already exists. Available only to create versions. Do you want to continue the creation of version?
							/// </summary>
							[DataMember]
							public string HasItemWarningMessage
							{
								get
								{
									if (_strings.ContainsKey("HasItemWarningMessage" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["HasItemWarningMessage" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("HasItemWarningMessage"))
									{
										return _strings["HasItemWarningMessage"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// View
							/// </summary>
							[DataMember]
							public string PreviewItem
							{
								get
								{
									if (_strings.ContainsKey("PreviewItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["PreviewItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("PreviewItem"))
									{
										return _strings["PreviewItem"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// History
							/// </summary>
							[DataMember]
							public string PreviewItemVersions
							{
								get
								{
									if (_strings.ContainsKey("PreviewItemVersions" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["PreviewItemVersions" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("PreviewItemVersions"))
									{
										return _strings["PreviewItemVersions"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Publish
							/// </summary>
							[DataMember]
							public string PublishItem
							{
								get
								{
									if (_strings.ContainsKey("PublishItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["PublishItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("PublishItem"))
									{
										return _strings["PublishItem"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshItem
							{
								get
								{
									if (_strings.ContainsKey("RefreshItem" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshItem" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshItem"))
									{
										return _strings["RefreshItem"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
							#region Widgets
				[DataContract]
				public partial class Widgets
				{
					private Dictionary<string, string> _strings = new Dictionary<string, string>();

					
					public Widgets()
					{
													_strings.Add("AddButton_en-us", "Add");
													_strings.Add("AddWindowTitle_en-us", "Add widget");
													_strings.Add("DeleteButton_en-us", "Delete");
													_strings.Add("EditButton_en-us", "Edit");
													_strings.Add("NameColumnDiscriminatorName_en-us", "Type");
													_strings.Add("NameColumnRegion_en-us", "Regions");
													_strings.Add("NameColumnSortOrder_en-us", "Order");
													_strings.Add("NameColumnStatusName_en-us", "Status");
													_strings.Add("NameColumnTitle_en-us", "Name");
													_strings.Add("NameColumnZoneName_en-us", "Zone name");
													_strings.Add("PublishAll_en-us", "Publish all");
													_strings.Add("PublishSelected_en-us", "Publish selected");
													_strings.Add("RefreshButton_en-us", "Refresh");
													_strings.Add("TitleColumnId_en-us", "Id");
													_strings.Add("TitleColumnTitle_en-us", "Title");
													_strings.Add("AddButton", "Добавить");
													_strings.Add("AddWindowTitle", "Добавление виджета");
													_strings.Add("DeleteButton", "Удалить");
													_strings.Add("EditButton", "Изменить");
													_strings.Add("NameColumnDiscriminatorName", "Тип");
													_strings.Add("NameColumnSortOrder", "Инд.");
													_strings.Add("NameColumnStatusName", "Статус");
													_strings.Add("NameColumnTitle", "Название");
													_strings.Add("NameColumnZoneName", "Название зоны");
													_strings.Add("PublishAll", "Публиковать все");
													_strings.Add("PublishSelected", "Публиковать выделенное");
													_strings.Add("RefreshButton", "Обновить");
													_strings.Add("TitleColumnId", "Ид.");
													_strings.Add("TitleColumnTitle", "Заголовок");
													_strings.Add("NameColumnRegion", "Регионы");
											}

					
											    /// <summary>
							/// Add
							/// </summary>
							[DataMember]
							public string AddButton
							{
								get
								{
									if (_strings.ContainsKey("AddButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddButton"))
									{
										return _strings["AddButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Add widget
							/// </summary>
							[DataMember]
							public string AddWindowTitle
							{
								get
								{
									if (_strings.ContainsKey("AddWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["AddWindowTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("AddWindowTitle"))
									{
										return _strings["AddWindowTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Delete
							/// </summary>
							[DataMember]
							public string DeleteButton
							{
								get
								{
									if (_strings.ContainsKey("DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["DeleteButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("DeleteButton"))
									{
										return _strings["DeleteButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Edit
							/// </summary>
							[DataMember]
							public string EditButton
							{
								get
								{
									if (_strings.ContainsKey("EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["EditButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("EditButton"))
									{
										return _strings["EditButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Type
							/// </summary>
							[DataMember]
							public string NameColumnDiscriminatorName
							{
								get
								{
									if (_strings.ContainsKey("NameColumnDiscriminatorName" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnDiscriminatorName" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnDiscriminatorName"))
									{
										return _strings["NameColumnDiscriminatorName"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Regions
							/// </summary>
							[DataMember]
							public string NameColumnRegion
							{
								get
								{
									if (_strings.ContainsKey("NameColumnRegion" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnRegion" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnRegion"))
									{
										return _strings["NameColumnRegion"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Order
							/// </summary>
							[DataMember]
							public string NameColumnSortOrder
							{
								get
								{
									if (_strings.ContainsKey("NameColumnSortOrder" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnSortOrder" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnSortOrder"))
									{
										return _strings["NameColumnSortOrder"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Status
							/// </summary>
							[DataMember]
							public string NameColumnStatusName
							{
								get
								{
									if (_strings.ContainsKey("NameColumnStatusName" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnStatusName" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnStatusName"))
									{
										return _strings["NameColumnStatusName"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Name
							/// </summary>
							[DataMember]
							public string NameColumnTitle
							{
								get
								{
									if (_strings.ContainsKey("NameColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnTitle"))
									{
										return _strings["NameColumnTitle"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Zone name
							/// </summary>
							[DataMember]
							public string NameColumnZoneName
							{
								get
								{
									if (_strings.ContainsKey("NameColumnZoneName" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["NameColumnZoneName" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("NameColumnZoneName"))
									{
										return _strings["NameColumnZoneName"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Publish all
							/// </summary>
							[DataMember]
							public string PublishAll
							{
								get
								{
									if (_strings.ContainsKey("PublishAll" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["PublishAll" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("PublishAll"))
									{
										return _strings["PublishAll"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Publish selected
							/// </summary>
							[DataMember]
							public string PublishSelected
							{
								get
								{
									if (_strings.ContainsKey("PublishSelected" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["PublishSelected" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("PublishSelected"))
									{
										return _strings["PublishSelected"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Refresh
							/// </summary>
							[DataMember]
							public string RefreshButton
							{
								get
								{
									if (_strings.ContainsKey("RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["RefreshButton" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("RefreshButton"))
									{
										return _strings["RefreshButton"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Id
							/// </summary>
							[DataMember]
							public string TitleColumnId
							{
								get
								{
									if (_strings.ContainsKey("TitleColumnId" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["TitleColumnId" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("TitleColumnId"))
									{
										return _strings["TitleColumnId"];
									}

									return string.Empty;
								}
								set {}
							}
												    /// <summary>
							/// Title
							/// </summary>
							[DataMember]
							public string TitleColumnTitle
							{
								get
								{
									if (_strings.ContainsKey("TitleColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()))
									{
										return _strings["TitleColumnTitle" + CultureInfo.CurrentUICulture.Name.ToLower()];
									}

									if (_strings.ContainsKey("TitleColumnTitle"))
									{
										return _strings["TitleColumnTitle"];
									}

									return string.Empty;
								}
								set {}
							}
										}
				#endregion
					#endregion
    }

