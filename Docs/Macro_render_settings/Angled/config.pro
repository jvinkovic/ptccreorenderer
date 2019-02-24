search_path_file $CREO_COMMON_FILES\afx\parts\prolibrary\search.pro
!------------------------------------------------------------
! Directory settings
!------------------------------------------------------------
pro_colormap_path c:\Neo Lab - Creo config\Setup\
pro_symbol_dir c:\Neo Lab - Creo config\Setup\Drawing settings\Symbols\
pro_dtl_setup_dir c:\Neo Lab - Creo config\Setup\Drawing settings\
pro_format_dir c:\Neo Lab - Creo config\Setup\Drawing settings\Formats\
start_model_dir d:\Creo - working dir\
trail_dir c:\Neo Lab - Creo config\Trail\
pro_font_dir c:\WINDOWS\fonts\
pro_table_dir c:\Neo Lab - Creo config\Setup\Drawing settings\Tables\
intf_profile_dir c:\Neo Lab - Creo config\Setup\Export Profiles\
hole_parameter_file_path c:\Neo Lab - Creo config\Setup\Hole database\
!------------------------------------------------------------
! File settings
!------------------------------------------------------------
drawing_setup_file c:\Neo Lab - Creo config\Setup\Drawing settings\my_dwg.dtl
pen_table_file c:\Neo Lab - Creo config\Setup\Drawing settings\table.pnt
mdl_tree_cfg_file c:\Neo Lab - Creo config\Setup\tree.cfg
system_colors_file c:\Neo Lab - Creo config\Setup\NEO_LAB_colors_ui.scl
!------------------------------------------------------------
! Start models
!------------------------------------------------------------
template_solidpart c:\Neo Lab - Creo config\Setup\my_start.prt
template_designasm c:\Neo Lab - Creo config\Setup\my_start.asm
format_setup_file c:\Neo Lab - Creo config\Setup\Drawing settings\my_dwg.dtl
!------------------------------------------------------------
! STL
!------------------------------------------------------------
intf3d_out_prop_chord_heights yes
intf3d_out_prop_step_sizes yes
intf3d_out_use_step_size yes
intf3d_out_configure_export yes
print3d_stl_export_type binary
print3d_stl_ud_chord_height yes
print3d_stl_ud_angle yes
print3d_stl_ud_step_size yes
export_profiles_stl c:\Neo Lab - Creo config\Setup\Render $ STL settings\NEO_LAB_STL_settings.dep_stl
!------------------------------------------------------------
! Render settings
!-----------------------------------------------------------
default_scene_filename c:\Neo Lab - Creo config\Setup\Render $ STL settings\NEO_LAB_render_scene.scn
save_scene_with_file no
texture_search_path c:\Neo Lab - Creo config\Angled\
save_texture_with_model yes

!------------------------------------------------------------
! PDF settings
!------------------------------------------------------------
pdf_use_pentable YES
!------------------------------------------------------------
! Other settings
!-----------------------------------------------------------
weld_ui_standard iso
display_axes yes
bell no
clock no
company_name Neo Lab
display_planes yes
display_plane_tags yes
display_points yes
display_point_tags YES
display shadewithedges
display_coord_sys yes
disp_trimetric_dwg_mode_view YES
highlight_new_dims YES
mass_property_calculate check_upon_save
model_tree_start YES
mp_calc_level ALL_MODELS
orientation ISOMETRIC
parenthesize_ref_dim YES
prompt_on_exit YES
pipe_solid_centerline NO
pro_unit_length UNIT_MM
pro_unit_mass unit_kilogram
pro_unit_sys mmks
rename_drawings_with_object BOTH
save_drawing_picture_file EMBED
spin_center_display NO
todays_date_note_format %dd.%mm.%yyyy.
tolerance_standard ISO
variable_plots_in_inches NO
web_enable_javascript on
intf2d_fit_incompatible_data no
spin_with_part_entities yes
tol_display YES
load_ui_customization_run_dir yes
tk_enable_ribbon_custom_save yes
enable_3dmodelspace_browser_tab no
enable_partcommunity_tab yes
intelligent_fastener_enabled yes
afx_enabled yes
windows_browser_type chromium_browser
web_browser_in_separate_window yes
blended_transparency NO
edge_display_quality high
enable_fsaa 4
sketcher_starts_in_2d yes
min_animation_steps 25
shade_quality 3
enable_ambient_occlusion no
sketcher_disp_grid yes
sketcher_dimension_autolock yes
sketcher_lock_modified_dims yes
frt_enabled yes
save_instance_accelerator ALWAYS
sketcher_set_grid_method dynamic
sketcher_grid_type cartesian
display_axis_tags yes
sketcher_line_width 2.50
default_dec_places 3
!------------------------------------------------------------
! MAPKEYS
!------------------------------------------------------------
! PDF EXPORT MAPKEY
mapkey pdf @MAPKEY_LABELpdf;~ Command `ProCmdExportPreview` ;\
mapkey(continued) ~ Command `ProCmdDwgPubSettings` ;~ Open `intf_profile` `opt_profile`;\
mapkey(continued) ~ Close `intf_profile` `opt_profile`;\
mapkey(continued) ~ Select `intf_profile` `opt_profile` 1 `PDF_export_settings`;\
mapkey(continued) ~ Activate `intf_profile` `OkPshBtn`;~ Command `ProCmdDwgPubExport` ;\
mapkey(continued) ~ Select `file_saveas` `ph_list.Filelist` 1 `PDF`;\
mapkey(continued) ~ Activate `file_saveas` `ph_list.Filelist` 1 `PDF`;\
mapkey(continued) ~ Activate `file_saveas` `OK`;~ Activate `UI Message Dialog` `ok`;\
mapkey(continued) ~ Activate `main_dlg_cur` `main_dlg_cur`;\
mapkey(continued) ~ Trail `UI Desktop` `UI Desktop` `ActivateOnFocus` `main_dlg_w3`;\
mapkey(continued) ~ Activate `main_dlg_cur` `main_dlg_cur`;
! SAVE, REGEN, DEFAULT VIEW
mapkey $F3 @MAPKEY_LABELspremanje;~ Command `ProCmdRegenPart` ;\
mapkey(continued) ~ Command `ProCmdRegenPart` ;~ Command `ProCmdViewDefault` ;\
mapkey(continued) ~ Close `main_dlg_cur` `appl_casc`;~ Command `ProCmdMmModelProperties` ;\
mapkey(continued) ~ Activate `mdlprops_dlg` `MASS_PROPS_lay_Controls.push_Change.lay_instance`;\
mapkey(continued) ~ Activate `mass_prop_dlg` `OkPush`;\
mapkey(continued) ~ Activate `mdlprops_dlg` `DlgClose_push`;~ Command `ProCmdModelSave` ;\
mapkey(continued) ~ Command `ProCmdFilePurge` ;~ Activate `0_std_confirm` `OK`;
!RENDER SETTINGS
mapkey $F5 @MAPKEY_LABELRender_settings;\
mapkey(continued) ~ Activate `main_dlg_cur` `page_View_control_btn` 1;\
mapkey(continued) ~ Select `main_dlg_cur` `View:casc340798662`;\
mapkey(continued) ~ Close `main_dlg_cur` `View:casc340798662`;\
mapkey(continued) ~ Command `ProCmdNamedViewsGalSelect`  `RENDER_VIEW`;\
mapkey(continued) ~ Command `ProCmdViewRefit` ;~ Command `ProCmdViewRenderScene`  1;\
mapkey(continued) ~ Select `pgl_combined_scene_file` `SceneTabs` 1 `EnvironmentTab`;\
mapkey(continued) ~ Select `pgl_combined_scene_file` `SceneTabs` 1 `LightTab`;\
mapkey(continued) ~ Select `pgl_combined_scene_file` `SceneTabs` 1 `BackgroundTab`;\
mapkey(continued) ~ Activate `pgl_combined_scene_file` `CommitClose`;
!RENDERING
mapkey $F6 @MAPKEY_LABELRendering;\
mapkey(continued) ~ Command `ProCmdViewRefit` ;\
mapkey(continued) ~ Activate `main_dlg_cur` `page_Applications_control_btn` 1;\
mapkey(continued) ~ Command `ProCmdPhotoRealRend`  1;~ Command `KeyShot_Render` ;\
mapkey(continued) ~ FocusOut `renderDialog` `FileNameInput`;\
mapkey(continued) ~ Open `renderDialog` `FileFormatDropdown`;\
mapkey(continued) ~ Close `renderDialog` `FileFormatDropdown`;\
mapkey(continued) ~ Select `renderDialog` `FileFormatDropdown` 1 `PNG`;\
mapkey(continued) ~ Activate `renderDialog` `FileFormatIncludeAlpha` 1;\
mapkey(continued) ~ Input `renderDialog` `ResolutionWidthInput` `1`;\
mapkey(continued) ~ Input `renderDialog` `ResolutionWidthInput` `19`;\
mapkey(continued) ~ Input `renderDialog` `ResolutionWidthInput` `192`;\
mapkey(continued) ~ Input `renderDialog` `ResolutionWidthInput` `1920`;\
mapkey(continued) ~ Update `renderDialog` `ResolutionWidthInput` `1920`;\
mapkey(continued) ~ Update `renderDialog` `RenderSamplesInput` `75`;\
mapkey(continued) ~ Activate `renderDialog` `UseRealtimeCheck` 0;\
mapkey(continued) ~ Activate `renderDialog` `CollapsibleCheck` 1;\
mapkey(continued) ~ Open `renderDialog` `PresetsOptionMenu`;\
mapkey(continued) ~ Close `renderDialog` `PresetsOptionMenu`;\
mapkey(continued) ~ Select `renderDialog` `PresetsOptionMenu` 1 `Product`;
!VIEW_ANGLE
mapkey $F7 @MAPKEY_LABELView_angled;;\
mapkey(continued) ~ Select `main_dlg_cur` `View:casc340798662`;\
mapkey(continued) ~ Close `main_dlg_cur` `View:casc340798662`;\
mapkey(continued) ~ Command `ProCmdNamedViewsGalSelect`  `ANGLED`;~ Command `ProCmdViewRefit`;