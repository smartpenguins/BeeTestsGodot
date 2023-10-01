extends Node2D


@export var speed:float = 400
@export var radius:float = 100

var start_point:Vector2 = Vector2.ZERO
var next_point:Vector2 = Vector2.ZERO

# Called when the node enters the scene tree for the first time.
func _ready():
	start_point = position
	next_point = position

var random:RandomNumberGenerator = RandomNumberGenerator.new()

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta:float):
	if position.distance_squared_to(next_point)<144:
		#square next_point = Vector2(random.randf_range(-radius,radius),random.randf_range(-radius,radius))+start_point
		var angal_rad:float = random.randf_range(-PI,PI)
		next_point = Vector2(cos(angal_rad),sin(angal_rad)) * random.randf_range(0,radius)+start_point
		
	position += delta * position.direction_to(next_point)*speed;
