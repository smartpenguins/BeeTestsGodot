extends Label

func _process(delta):
	set_text("FPS: %d" % Engine.get_frames_per_second())
	
func _input(event):
	if event.is_action_pressed("2D"):
		get_tree().change_scene_to_file("res://2D/Test2D.tscn")
	if event.is_action_pressed("3D"):
		get_tree().change_scene_to_file("res://3D/Test3D.tscn")
	if event.is_action_pressed("vsync"):
		if DisplayServer.window_get_vsync_mode()==DisplayServer.VSYNC_ENABLED:
			DisplayServer.window_set_vsync_mode(DisplayServer.VSYNC_DISABLED)
		else:
			DisplayServer.window_set_vsync_mode(DisplayServer.VSYNC_ENABLED)
			
