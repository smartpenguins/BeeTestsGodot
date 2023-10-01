extends Node

@export var canvasItem : CanvasItem
@export var action = "info"
@export var toggle = false;

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _input(event):
	if(event.is_action_pressed(action)):
		if toggle:
			canvasItem.visible=!canvasItem.visible
		else:
			canvasItem.visible=true
