extends Label


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	set_text("FPS: %d" % Engine.get_frames_per_second())


func _input(event):
	if event.is_action_pressed("restart"):
		get_tree().reload_current_scene()
	if event.is_action_pressed("vsync"):
		if DisplayServer.window_get_vsync_mode()==DisplayServer.VSYNC_ENABLED:
			DisplayServer.window_set_vsync_mode(DisplayServer.VSYNC_DISABLED)
		else:
			DisplayServer.window_set_vsync_mode(DisplayServer.VSYNC_ENABLED)
