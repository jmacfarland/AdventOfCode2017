//Advent of Code day 3
//Jamison MacFarland

let realInput = 361527;
let testInput = 10;

getCoordinates(realInput);

function getCoordinates(num){
    var x = 0;
    var y = 0;
    var dx = 1;
    var dy = 0;

    var current_length = 0;//current side length
    var segment_length = 1;//current side length limit

    for(i = 0; i < num - 1; i++){
        x += dx;
        y += dy;
        current_length++;
        

        if(current_length == segment_length){
            current_length = 0;

            var buffer = dx;
            dx = -dy;
            dy = buffer;

            if(dy == 0){
                segment_length++;
            }
        }
    }

    console.log('(' + x + ', ' + y + ')');
}