extends Node3D

var cube := preload("res://cube.tscn")
@onready var count = $"../VBoxContainer/Count"

@export var key := "1"

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

	
func _input(event):
	if event.is_action_pressed(key):
		count.add_count(10)
		for i in 10:
			add_child(cube.instantiate())
