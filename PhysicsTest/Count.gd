extends Label

@export var count := 0;


# Called when the node enters the scene tree for the first time.
func _ready():
	update_text()
	pass # Replace with function body.

func add_count(amount):
	count+=amount
	update_text()
	
func update_text():
	set_text("Count: %d" % count)
