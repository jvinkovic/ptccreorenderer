mapkey $F4 @MAPKEY_LABELRENDER_MACRO;\
mapkey(continued) ~ CellSelect `main_dlg_cur` `PHTLeft.AssyTree` `` ``;\
mapkey(continued) ~ Activate `main_dlg_cur` `page_View_control_btn` 1;\
mapkey(continued) ~ FocusOut `main_dlg_cur` `PHTLeft.EditPanel`;\
mapkey(continued) ~ Select `main_dlg_cur` `View:casc340798662`;\
mapkey(continued) ~ Close `main_dlg_cur` `View:casc340798662`;\
mapkey(continued) ~ Command `ProCmdNamedViewsGalSelect`  `RENDER_VIEW`;\
mapkey(continued) ~ FocusIn `main_dlg_cur` `PHTLeft.EditPanel`;~ Command `ProCmdViewRefit` ;\
mapkey(continued) ~ Activate `main_dlg_cur` `page_Applications_control_btn` 1;\
mapkey(continued) ~ Command `ProCmdPhotoRealRend`  1;~ Command `KeyShot_Render` ;\
mapkey(continued) ~ FocusOut `renderDialog` `FileNameInput`;\
mapkey(continued) ~ Activate `renderDialog` `UseRealtimeCheck` 0;\
mapkey(continued) ~ Activate `renderDialog` `CollapsibleCheck` 1;\
mapkey(continued) ~ Open `renderDialog` `PresetsOptionMenu`;\
mapkey(continued) ~ Close `renderDialog` `PresetsOptionMenu`;\
mapkey(continued) ~ Select `renderDialog` `PresetsOptionMenu` 1 `Product`;\
mapkey(continued) ~ Update `renderDialog` `RenderSamplesInput` `75`;\
mapkey(continued) ~ Input `renderDialog` `ResolutionWidthInput` `1`;\
mapkey(continued) ~ Input `renderDialog` `ResolutionWidthInput` `19`;\
mapkey(continued) ~ Input `renderDialog` `ResolutionWidthInput` `192`;\
mapkey(continued) ~ Input `renderDialog` `ResolutionWidthInput` `1920`;\
mapkey(continued) ~ Update `renderDialog` `ResolutionWidthInput` `1920`;\
mapkey(continued) ~ Open `renderDialog` `FileFormatDropdown`;\
mapkey(continued) ~ Close `renderDialog` `FileFormatDropdown`;\
mapkey(continued) ~ Select `renderDialog` `FileFormatDropdown` 1 `PNG`;\
mapkey(continued) ~ Activate `renderDialog` `FileFormatIncludeAlpha` 1;\
mapkey(continued) ~ Activate `renderDialog` `FileBrowseButton`;\
mapkey(continued) ~ Trail `UI Desktop` `UI Desktop` `DLG_PREVIEW_POST` `file_open`;\
mapkey(continued) ~ Activate `file_open` `Current Dir`;\
mapkey(continued) ~ Input `file_open` `Inputname` `A21341_KAT_HA`;\
mapkey(continued) ~ Update `file_open` `Inputname` `A21341_KAT_HA`;\
mapkey(continued) ~ Command `ProFileSelPushOpen@context_dlg_open_cmd` ;\
mapkey(continued) ~ Activate `renderDialog` `RenderCommitRender`;\
mapkey(continued) ~ Activate `renderDialog` `RenderCommitCancel`;
