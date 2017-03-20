using System;
using System.Runtime.Serialization;
/// <summary>
/// Список действий Qp
/// </summary>
namespace QA.Engine.Administration.WebApp.Actions
{
	/// <summary>
	/// Список действий Qp
	/// </summary>
	[DataContract]
	public class QpActionCodes
	{

				[DataMember]
				public string home = @"home";

				[DataMember]
				public string about = @"about";

				[DataMember]
				public string refresh_db = @"refresh_db";

				[DataMember]
				public string edit_profile = @"edit_profile";

				[DataMember]
				public string update_profile = @"update_profile";

				[DataMember]
				public string refresh_profile = @"refresh_profile";

				[DataMember]
				public string list_site = @"list_site";

				[DataMember]
				public string new_site = @"new_site";

				[DataMember]
				public string refresh_sites = @"refresh_sites";

				[DataMember]
				public string cancel_site = @"cancel_site";

				[DataMember]
				public string edit_site = @"edit_site";

				[DataMember]
				public string save_site = @"save_site";

				[DataMember]
				public string update_site = @"update_site";

				[DataMember]
				public string remove_site = @"remove_site";

				[DataMember]
				public string multiple_remove_site = @"multiple_remove_site";

				[DataMember]
				public string copy_site = @"copy_site";

				[DataMember]
				public string assemble_site = @"assemble_site";

				[DataMember]
				public string assemble_contents = @"assemble_contents";

				[DataMember]
				public string refresh_site = @"refresh_site";

				[DataMember]
				public string capture_lock_site = @"capture_lock_site";

				[DataMember]
				public string search_in_articles = @"search_in_articles";

				[DataMember]
				public string refresh_search_in_articles = @"refresh_search_in_articles";

				[DataMember]
				public string site_library = @"site_library";

				[DataMember]
				public string popup_site_library = @"popup_site_library";

				[DataMember]
				public string refresh_site_library = @"refresh_site_library";

				[DataMember]
				public string new_site_folder = @"new_site_folder";

				[DataMember]
				public string save_site_folder = @"save_site_folder";

				[DataMember]
				public string update_site_folder = @"update_site_folder";

				[DataMember]
				public string refresh_site_folder = @"refresh_site_folder";

				[DataMember]
				public string edit_site_folder = @"edit_site_folder";

				[DataMember]
				public string remove_site_folder = @"remove_site_folder";

				[DataMember]
				public string new_content_folder = @"new_content_folder";

				[DataMember]
				public string save_content_folder = @"save_content_folder";

				[DataMember]
				public string update_content_folder = @"update_content_folder";

				[DataMember]
				public string refresh_content_folder = @"refresh_content_folder";

				[DataMember]
				public string edit_content_folder = @"edit_content_folder";

				[DataMember]
				public string remove_content_folder = @"remove_content_folder";

				[DataMember]
				public string multiple_remove_site_file = @"multiple_remove_site_file";

				[DataMember]
				public string remove_site_file = @"remove_site_file";

				[DataMember]
				public string preview_site_file = @"preview_site_file";

				[DataMember]
				public string download_site_file = @"download_site_file";

				[DataMember]
				public string edit_site_file = @"edit_site_file";

				[DataMember]
				public string update_site_file = @"update_site_file";

				[DataMember]
				public string multiple_remove_content_file = @"multiple_remove_content_file";

				[DataMember]
				public string remove_content_file = @"remove_content_file";

				[DataMember]
				public string preview_content_file = @"preview_content_file";

				[DataMember]
				public string download_content_file = @"download_content_file";

				[DataMember]
				public string edit_content_file = @"edit_content_file";

				[DataMember]
				public string update_content_file = @"update_content_file";

				[DataMember]
				public string new_content_group = @"new_content_group";

				[DataMember]
				public string edit_content_group = @"edit_content_group";

				[DataMember]
				public string save_content_group = @"save_content_group";

				[DataMember]
				public string update_content_group = @"update_content_group";

				[DataMember]
				public string remove_content_group = @"remove_content_group";

				[DataMember]
				public string refresh_content_group = @"refresh_content_group";

				[DataMember]
				public string refresh_content_groups = @"refresh_content_groups";

				[DataMember]
				public string list_content = @"list_content";

				[DataMember]
				public string new_content = @"new_content";

				[DataMember]
				public string refresh_contents = @"refresh_contents";

				[DataMember]
				public string save_content = @"save_content";

				[DataMember]
				public string edit_content = @"edit_content";

				[DataMember]
				public string update_content = @"update_content";

				[DataMember]
				public string remove_content = @"remove_content";

				[DataMember]
				public string multiple_remove_content = @"multiple_remove_content";

				[DataMember]
				public string copy_content = @"copy_content";

				[DataMember]
				public string refresh_content = @"refresh_content";

				[DataMember]
				public string content_library = @"content_library";

				[DataMember]
				public string popup_content_library = @"popup_content_library";

				[DataMember]
				public string refresh_content_library = @"refresh_content_library";

				[DataMember]
				public string multiple_select_contents_for_union = @"multiple_select_contents_for_union";

				[DataMember]
				public string list_field = @"list_field";

				[DataMember]
				public string new_field = @"new_field";

				[DataMember]
				public string refresh_fields = @"refresh_fields";

				[DataMember]
				public string save_field = @"save_field";

				[DataMember]
				public string edit_field = @"edit_field";

				[DataMember]
				public string update_field = @"update_field";

				[DataMember]
				public string remove_field = @"remove_field";

				[DataMember]
				public string multiple_remove_field = @"multiple_remove_field";

				[DataMember]
				public string refresh_field = @"refresh_field";

				[DataMember]
				public string list_article = @"list_article";

				[DataMember]
				public string refresh_articles = @"refresh_articles";

				[DataMember]
				public string select_article = @"select_article";

				[DataMember]
				public string multiple_select_article = @"multiple_select_article";

				[DataMember]
				public string cancel_article = @"cancel_article";

				[DataMember]
				public string new_article = @"new_article";

				[DataMember]
				public string save_article = @"save_article";

				[DataMember]
				public string edit_article = @"edit_article";

				[DataMember]
				public string update_article = @"update_article";

				[DataMember]
				public string remove_article = @"remove_article";

				[DataMember]
				public string multiple_remove_article = @"multiple_remove_article";

				[DataMember]
				public string copy_article = @"copy_article";

				[DataMember]
				public string refresh_article = @"refresh_article";

				[DataMember]
				public string move_to_archive_article = @"move_to_archive_article";

				[DataMember]
				public string capture_lock_article = @"capture_lock_article";

				[DataMember]
				public string multiple_move_to_archive_article = @"multiple_move_to_archive_article";

				[DataMember]
				public string preview_article_version = @"preview_article_version";

				[DataMember]
				public string compare_article_version_with_current = @"compare_article_version_with_current";

				[DataMember]
				public string compare_article_versions = @"compare_article_versions";

				[DataMember]
				public string refresh_article_versions = @"refresh_article_versions";

				[DataMember]
				public string restore_article_version = @"restore_article_version";

				[DataMember]
				public string remove_article_version = @"remove_article_version";

				[DataMember]
				public string refresh_article_version = @"refresh_article_version";

				[DataMember]
				public string multiple_remove_article_version = @"multiple_remove_article_version";

				[DataMember]
				public string list_article_version = @"list_article_version";

				[DataMember]
				public string list_virtual_content = @"list_virtual_content";

				[DataMember]
				public string new_virtual_content = @"new_virtual_content";

				[DataMember]
				public string refresh_virtual_contents = @"refresh_virtual_contents";

				[DataMember]
				public string save_virtual_content = @"save_virtual_content";

				[DataMember]
				public string edit_virtual_content = @"edit_virtual_content";

				[DataMember]
				public string update_virtual_content = @"update_virtual_content";

				[DataMember]
				public string remove_virtual_content = @"remove_virtual_content";

				[DataMember]
				public string multiple_remove_virtual_content = @"multiple_remove_virtual_content";

				[DataMember]
				public string refresh_virtual_content = @"refresh_virtual_content";

				[DataMember]
				public string list_virtual_field = @"list_virtual_field";

				[DataMember]
				public string refresh_virtual_fields = @"refresh_virtual_fields";

				[DataMember]
				public string edit_virtual_field = @"edit_virtual_field";

				[DataMember]
				public string update_virtual_field = @"update_virtual_field";

				[DataMember]
				public string refresh_virtual_field = @"refresh_virtual_field";

				[DataMember]
				public string list_virtual_article = @"list_virtual_article";

				[DataMember]
				public string refresh_virtual_article = @"refresh_virtual_article";

				[DataMember]
				public string view_virtual_article = @"view_virtual_article";

				[DataMember]
				public string refresh_virtual_articles = @"refresh_virtual_articles";

				[DataMember]
				public string view_archive_article = @"view_archive_article";

				[DataMember]
				public string restore_from_archive_article = @"restore_from_archive_article";

				[DataMember]
				public string multiple_restore_from_archive_article = @"multiple_restore_from_archive_article";

				[DataMember]
				public string list_archive_article = @"list_archive_article";

				[DataMember]
				public string multiple_remove_archive_article = @"multiple_remove_archive_article";

				[DataMember]
				public string remove_archive_article = @"remove_archive_article";

				[DataMember]
				public string refresh_archive_article = @"refresh_archive_article";

				[DataMember]
				public string refresh_archive_articles = @"refresh_archive_articles";

				[DataMember]
				public string list_action_log = @"list_action_log";

				[DataMember]
				public string list_button_trace = @"list_button_trace";

				[DataMember]
				public string list_removed_entities = @"list_removed_entities";

				[DataMember]
				public string refresh_action_log = @"refresh_action_log";

				[DataMember]
				public string list_successful_sessions = @"list_successful_sessions";

				[DataMember]
				public string list_failed_sessions = @"list_failed_sessions";

				[DataMember]
				public string multiple_select_site = @"multiple_select_site";

				[DataMember]
				public string multiple_select_content = @"multiple_select_content";

				[DataMember]
				public string list_custom_action = @"list_custom_action";

				[DataMember]
				public string new_custom_action = @"new_custom_action";

				[DataMember]
				public string refresh_custom_actions = @"refresh_custom_actions";

				[DataMember]
				public string edit_custom_action = @"edit_custom_action";

				[DataMember]
				public string save_custom_action = @"save_custom_action";

				[DataMember]
				public string update_custom_action = @"update_custom_action";

				[DataMember]
				public string remove_custom_action = @"remove_custom_action";

				[DataMember]
				public string multiple_remove_custom_action = @"multiple_remove_custom_action";

				[DataMember]
				public string refresh_custom_action = @"refresh_custom_action";

				[DataMember]
				public string apply_field_default_value = @"apply_field_default_value";

				[DataMember]
				public string recreate_dynamic_images = @"recreate_dynamic_images";

				[DataMember]
				public string clear_content = @"clear_content";

				[DataMember]
				public string list_user = @"list_user";

				[DataMember]
				public string multiple_select_user = @"multiple_select_user";

				[DataMember]
				public string refresh_users = @"refresh_users";

				[DataMember]
				public string new_user = @"new_user";

				[DataMember]
				public string save_user = @"save_user";

				[DataMember]
				public string copy_user = @"copy_user";

				[DataMember]
				public string edit_user = @"edit_user";

				[DataMember]
				public string update_user = @"update_user";

				[DataMember]
				public string refresh_user = @"refresh_user";

				[DataMember]
				public string remove_user = @"remove_user";

				[DataMember]
				public string list_user_group = @"list_user_group";

				[DataMember]
				public string refresh_user_groups = @"refresh_user_groups";

				[DataMember]
				public string new_user_group = @"new_user_group";

				[DataMember]
				public string save_user_group = @"save_user_group";

				[DataMember]
				public string copy_user_group = @"copy_user_group";

				[DataMember]
				public string edit_user_group = @"edit_user_group";

				[DataMember]
				public string update_user_group = @"update_user_group";

				[DataMember]
				public string refresh_user_group = @"refresh_user_group";

				[DataMember]
				public string remove_user_group = @"remove_user_group";

				[DataMember]
				public string list_site_permission = @"list_site_permission";

				[DataMember]
				public string refresh_site_permissions = @"refresh_site_permissions";

				[DataMember]
				public string new_site_permission = @"new_site_permission";

				[DataMember]
				public string save_site_permission = @"save_site_permission";

				[DataMember]
				public string edit_site_permission = @"edit_site_permission";

				[DataMember]
				public string update_site_permission = @"update_site_permission";

				[DataMember]
				public string refresh_site_permission = @"refresh_site_permission";

				[DataMember]
				public string remove_site_permission = @"remove_site_permission";

				[DataMember]
				public string multiple_remove_site_permission = @"multiple_remove_site_permission";

				[DataMember]
				public string list_content_permission = @"list_content_permission";

				[DataMember]
				public string refresh_content_permissions = @"refresh_content_permissions";

				[DataMember]
				public string new_content_permission = @"new_content_permission";

				[DataMember]
				public string save_content_permission = @"save_content_permission";

				[DataMember]
				public string edit_content_permission = @"edit_content_permission";

				[DataMember]
				public string update_content_permission = @"update_content_permission";

				[DataMember]
				public string refresh_content_permission = @"refresh_content_permission";

				[DataMember]
				public string remove_content_permission = @"remove_content_permission";

				[DataMember]
				public string multiple_remove_content_permission = @"multiple_remove_content_permission";

				[DataMember]
				public string list_article_permission = @"list_article_permission";

				[DataMember]
				public string refresh_article_permissions = @"refresh_article_permissions";

				[DataMember]
				public string new_article_permission = @"new_article_permission";

				[DataMember]
				public string save_article_permission = @"save_article_permission";

				[DataMember]
				public string edit_article_permission = @"edit_article_permission";

				[DataMember]
				public string update_article_permission = @"update_article_permission";

				[DataMember]
				public string refresh_article_permission = @"refresh_article_permission";

				[DataMember]
				public string remove_article_permission = @"remove_article_permission";

				[DataMember]
				public string multiple_remove_article_permission = @"multiple_remove_article_permission";

				[DataMember]
				public string list_workflow_permission = @"list_workflow_permission";

				[DataMember]
				public string refresh_workflow_permissions = @"refresh_workflow_permissions";

				[DataMember]
				public string new_workflow_permission = @"new_workflow_permission";

				[DataMember]
				public string save_workflow_permission = @"save_workflow_permission";

				[DataMember]
				public string edit_workflow_permission = @"edit_workflow_permission";

				[DataMember]
				public string update_workflow_permission = @"update_workflow_permission";

				[DataMember]
				public string refresh_workflow_permission = @"refresh_workflow_permission";

				[DataMember]
				public string remove_workflow_permission = @"remove_workflow_permission";

				[DataMember]
				public string multiple_remove_workflow_permission = @"multiple_remove_workflow_permission";

				[DataMember]
				public string list_site_folder_permission = @"list_site_folder_permission";

				[DataMember]
				public string refresh_site_folder_permissions = @"refresh_site_folder_permissions";

				[DataMember]
				public string new_site_folder_permission = @"new_site_folder_permission";

				[DataMember]
				public string save_site_folder_permission = @"save_site_folder_permission";

				[DataMember]
				public string edit_site_folder_permission = @"edit_site_folder_permission";

				[DataMember]
				public string update_site_folder_permission = @"update_site_folder_permission";

				[DataMember]
				public string refresh_site_folder_permission = @"refresh_site_folder_permission";

				[DataMember]
				public string remove_site_folder_permission = @"remove_site_folder_permission";

				[DataMember]
				public string multiple_remove_site_folder_permission = @"multiple_remove_site_folder_permission";

				[DataMember]
				public string select_user = @"select_user";

				[DataMember]
				public string select_user_group = @"select_user_group";

				[DataMember]
				public string enable_article_permissions = @"enable_article_permissions";

				[DataMember]
				public string list_child_content_permission = @"list_child_content_permission";

				[DataMember]
				public string refresh_child_content_permissions = @"refresh_child_content_permissions";

				[DataMember]
				public string multiple_change_child_content_permission = @"multiple_change_child_content_permission";

				[DataMember]
				public string multiple_remove_child_content_permission = @"multiple_remove_child_content_permission";

				[DataMember]
				public string change_all_child_content_permission = @"change_all_child_content_permission";

				[DataMember]
				public string remove_all_child_content_permission = @"remove_all_child_content_permission";

				[DataMember]
				public string change_child_content_permission = @"change_child_content_permission";

				[DataMember]
				public string remove_child_content_permission = @"remove_child_content_permission";

				[DataMember]
				public string list_child_article_permission = @"list_child_article_permission";

				[DataMember]
				public string refresh_child_article_permissions = @"refresh_child_article_permissions";

				[DataMember]
				public string multiple_change_child_article_permission = @"multiple_change_child_article_permission";

				[DataMember]
				public string multiple_remove_child_article_permission = @"multiple_remove_child_article_permission";

				[DataMember]
				public string change_all_child_article_permission = @"change_all_child_article_permission";

				[DataMember]
				public string remove_all_child_article_permission = @"remove_all_child_article_permission";

				[DataMember]
				public string change_child_article_permission = @"change_child_article_permission";

				[DataMember]
				public string remove_child_article_permission = @"remove_child_article_permission";

				[DataMember]
				public string save_child_content_permission = @"save_child_content_permission";

				[DataMember]
				public string save_child_article_permission = @"save_child_article_permission";

				[DataMember]
				public string list_notification = @"list_notification";

				[DataMember]
				public string refresh_notifications = @"refresh_notifications";

				[DataMember]
				public string new_notification = @"new_notification";

				[DataMember]
				public string save_notification = @"save_notification";

				[DataMember]
				public string edit_notification = @"edit_notification";

				[DataMember]
				public string update_notification = @"update_notification";

				[DataMember]
				public string refresh_notification = @"refresh_notification";

				[DataMember]
				public string remove_notification = @"remove_notification";

				[DataMember]
				public string edit_notification_template_format = @"edit_notification_template_format";

				[DataMember]
				public string update_notification_template_format = @"update_notification_template_format";

				[DataMember]
				public string refresh_notification_template_format = @"refresh_notification_template_format";

				[DataMember]
				public string action_permission_tree = @"action_permission_tree";

				[DataMember]
				public string refresh_action_permission_tree = @"refresh_action_permission_tree";

				[DataMember]
				public string refresh_entity_type_permission_node = @"refresh_entity_type_permission_node";

				[DataMember]
				public string refresh_action_permission_node = @"refresh_action_permission_node";

				[DataMember]
				public string change_entity_type_permission = @"change_entity_type_permission";

				[DataMember]
				public string update_entity_type_permission_changes = @"update_entity_type_permission_changes";

				[DataMember]
				public string remove_entity_type_permission_changes = @"remove_entity_type_permission_changes";

				[DataMember]
				public string change_action_permission = @"change_action_permission";

				[DataMember]
				public string update_action_permission_changes = @"update_action_permission_changes";

				[DataMember]
				public string remove_action_permission_changes = @"remove_action_permission_changes";

				[DataMember]
				public string list_entity_type_permission = @"list_entity_type_permission";

				[DataMember]
				public string refresh_entity_type_permissions = @"refresh_entity_type_permissions";

				[DataMember]
				public string new_entity_type_permission = @"new_entity_type_permission";

				[DataMember]
				public string save_entity_type_permission = @"save_entity_type_permission";

				[DataMember]
				public string edit_entity_type_permission = @"edit_entity_type_permission";

				[DataMember]
				public string update_entity_type_permission = @"update_entity_type_permission";

				[DataMember]
				public string refresh_entity_type_permission = @"refresh_entity_type_permission";

				[DataMember]
				public string remove_entity_type_permission = @"remove_entity_type_permission";

				[DataMember]
				public string multiple_remove_entity_type_permission = @"multiple_remove_entity_type_permission";

				[DataMember]
				public string list_action_permission = @"list_action_permission";

				[DataMember]
				public string refresh_action_permissions = @"refresh_action_permissions";

				[DataMember]
				public string new_action_permission = @"new_action_permission";

				[DataMember]
				public string save_action_permission = @"save_action_permission";

				[DataMember]
				public string edit_action_permission = @"edit_action_permission";

				[DataMember]
				public string update_action_permission = @"update_action_permission";

				[DataMember]
				public string refresh_action_permission = @"refresh_action_permission";

				[DataMember]
				public string remove_action_permission = @"remove_action_permission";

				[DataMember]
				public string multiple_remove_action_permission = @"multiple_remove_action_permission";

				[DataMember]
				public string unbind_notification = @"unbind_notification";

				[DataMember]
				public string multiple_remove_notification = @"multiple_remove_notification";

				[DataMember]
				public string assemble_notification = @"assemble_notification";

				[DataMember]
				public string multiple_assemble_notification = @"multiple_assemble_notification";

				[DataMember]
				public string list_visual_editor_plugin = @"list_visual_editor_plugin";

				[DataMember]
				public string new_visual_editor_plugin = @"new_visual_editor_plugin";

				[DataMember]
				public string edit_visual_editor_plugin = @"edit_visual_editor_plugin";

				[DataMember]
				public string update_visual_editor_plugin = @"update_visual_editor_plugin";

				[DataMember]
				public string refresh_visual_editor_plugin = @"refresh_visual_editor_plugin";

				[DataMember]
				public string remove_visual_editor_plugin = @"remove_visual_editor_plugin";

				[DataMember]
				public string save_visual_editor_plugin = @"save_visual_editor_plugin";

				[DataMember]
				public string save_article_and_up = @"save_article_and_up";

				[DataMember]
				public string update_article_and_up = @"update_article_and_up";

				[DataMember]
				public string refresh_visual_editor_plugins = @"refresh_visual_editor_plugins";

				[DataMember]
				public string list_content_permission_for_child = @"list_content_permission_for_child";

				[DataMember]
				public string list_article_permission_for_child = @"list_article_permission_for_child";

				[DataMember]
				public string custom_634892886978894446 = @"custom_634892886978894446";

				[DataMember]
				public string custom_634892891261583752 = @"custom_634892891261583752";

				[DataMember]
				public string custom_634892893022026292 = @"custom_634892893022026292";

				[DataMember]
				public string custom_634898094705248738 = @"custom_634898094705248738";

				[DataMember]
				public string custom_634898925753352599 = @"custom_634898925753352599";

				[DataMember]
				public string custom_634901353592264365 = @"custom_634901353592264365";

				[DataMember]
				public string list_visual_editor_style = @"list_visual_editor_style";

				[DataMember]
				public string new_visual_editor_style = @"new_visual_editor_style";

				[DataMember]
				public string edit_visual_editor_style = @"edit_visual_editor_style";

				[DataMember]
				public string update_visual_editor_style = @"update_visual_editor_style";

				[DataMember]
				public string refresh_visual_editor_style = @"refresh_visual_editor_style";

				[DataMember]
				public string remove_visual_editor_style = @"remove_visual_editor_style";

				[DataMember]
				public string save_visual_editor_style = @"save_visual_editor_style";

				[DataMember]
				public string refresh_visual_editor_styles = @"refresh_visual_editor_styles";

				[DataMember]
				public string list_workflow = @"list_workflow";

				[DataMember]
				public string new_workflow = @"new_workflow";

				[DataMember]
				public string edit_workflow = @"edit_workflow";

				[DataMember]
				public string list_status_type = @"list_status_type";

				[DataMember]
				public string new_status_type = @"new_status_type";

				[DataMember]
				public string edit_status_type = @"edit_status_type";

				[DataMember]
				public string update_status_type = @"update_status_type";

				[DataMember]
				public string refresh_status_type = @"refresh_status_type";

				[DataMember]
				public string remove_status_type = @"remove_status_type";

				[DataMember]
				public string save_status_type = @"save_status_type";

				[DataMember]
				public string refresh_status_types = @"refresh_status_types";

				[DataMember]
				public string update_workflow = @"update_workflow";

				[DataMember]
				public string refresh_workflow = @"refresh_workflow";

				[DataMember]
				public string remove_workflow = @"remove_workflow";

				[DataMember]
				public string save_workflow = @"save_workflow";

				[DataMember]
				public string refresh_workflows = @"refresh_workflows";
				}
}


