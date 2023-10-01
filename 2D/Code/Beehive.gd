extends Node

@export var bee_scene: PackedScene
@export var maxCount = 0
@export var lable: Label
@export var key = "cs"

var run = false;
var total_count = 0
# Called when the node enters the scene tree for the first time.
func _ready():
	pass


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if total_count < maxCount:
		for n in min(maxCount-total_count,200):
			add_child(bee_scene.instantiate())
			total_count+=1
		lable.set_text("Count: %d" % total_count)
	
func _input(event):
	if event.is_action_pressed(key):
		run=true
		maxCount+=1000
	if event.is_action_pressed("restart"):
		get_tree().reload_current_scene()
	if run && event.is_action_pressed("jump"):
		maxCount+=10000
	if run && event.is_action_pressed("enter"):
		maxCount+=100000
	if event.is_action_pressed("mmf")||event.is_action_pressed("mmq"):
		total_count+=1000
		lable.set_text("Count: %d" % total_count)
