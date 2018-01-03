var $svgSel = $('#pto-drawer');
var svg = $svgSel.get(0);
var containerElement = svg.parentElement;
svg.width = containerElement.offsetWidth;
svg.height = containerElement.offsetHeight;

//Изменение размера svg при изменении размера контейнера
containerElement.addEventListener('resize', function resizeSvg() {
    svg.width = containerElement.offsetWidth;//containerElement.offsetWidth;
    svg.height = containerElement.offsetHeight;//containerElement.offsetHeight;
}, false);

$(document).ready(function () {
    var spinner = $('#spinner');
    spinner.spinner({
        min: 10,
        max: 100
    });
    spinner.spinner('value', spinner.spinner('option', 'min'));
    spinner.on('spin', updateSvg);
    $('input').on('keyup keydown change input', updateSvg);
    updateSvg();
})

function updateSvg() {
    $.ajax({
        url: '/pto/update',
        //url: '/pto/update',
        type: 'post',
        data: {
            needCircle: getNeedCircle(),
            radius: getRadius()
        },
        datatype: 'html',
        processdata: true,
        success: function (html) {
            $svgSel.html(html);
        }
    })
}

/* click inside svg */
$svgSel.click(function (e) {
    var mousePos = getMousePos(svg, e);
    var x = mousePos.x;
    var y = mousePos.y;
    var buttons = ['left', 'middle', 'right'];
    var button = buttons[e.which === 1 ? (e.ctrlKey ? 2 : 0) : e.which]
$.ajax({
    url: '/pto/addpoint',
    //url: '/pto/addPoint',
    type: 'POST',
    data: {
        x: x,
        y: y,
        button: button
    },
    datatype: 'html',
    processdata: true,
    success: function (html) {
        $svgSel.html(html);
    }
});
});

function getRadius() {
    return Number($('#spinner').spinner('value'));
}

function getNeedCircle() {
    return $('#needCircles').is(':checked');
}

/* get mouse position relativ to svg */
function getMousePos(svg, evt) {
    var rect = svg.getBoundingClientRect();
    return {
        x: evt.clientX - rect.left,
        y: evt.clientY - rect.top
    };
}
////x, y, button, needCircle, radius
//function loadSvg(params) {
//    $svgSel.load('/Pto/GetSvg?' + encodeData(params));
//}

//function encodeData(data) {
//    return Object.keys(data).map(function (key) {
//        return [key, data[key]].map(encodeURIComponent).join("=");
//    }).join("&");
//}

