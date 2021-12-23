$('.list-group-item').on('click', function () {
    var $this = $(this);
    var $alias = $this.data('alias');

    $('.active').removeClass('active');
    $this.toggleClass('active')
    console.log($alias);

})

function reply_click(clicked_id) {
    var Main = document.getElementById("Maindish").style.display;
    var Side = document.getElementById("SideDish").style.display;
    var Soup = document.getElementById("Soup").style.display;
    var Drink = document.getElementById("Drink").style.display;
    if (clicked_id == "list-Maindish-list")
        if (Main === "none") {
            document.getElementById("Maindish").style.display = "block";
            document.getElementById("SideDish").style.display = "none";
            document.getElementById("Soup").style.display = "none";
            document.getElementById("Drink").style.display = "none";
        } else {
            document.getElementById("SideDish").style.display = "block";
        }
    if (clicked_id == "list-SideDish-list")
        if (Side === "none") {
            document.getElementById("SideDish").style.display = "block";
            document.getElementById("Maindish").style.display = "none";
            document.getElementById("Soup").style.display = "none";
            document.getElementById("Drink").style.display = "none";
        } else {
            document.getElementById("SideDish").style.display = "block";
        }
    if (clicked_id == "list-Soup-list")
        if (Soup === "none") {
            document.getElementById("Soup").style.display = "block";
            document.getElementById("Maindish").style.display = "none";
            document.getElementById("SideDish").style.display = "none";
            document.getElementById("Drink").style.display = "none";
        } else {
            document.getElementById("Soup").style.display = "block";
        }
    if (clicked_id == "list-Drink-list")
        if (Drink === "none") {
            document.getElementById("Drink").style.display = "block";
            document.getElementById("Maindish").style.display = "none";
            document.getElementById("SideDish").style.display = "none";
            document.getElementById("Soup").style.display = "none";
        } else {
            document.getElementById("Drink").style.display = "block";
        }
}

