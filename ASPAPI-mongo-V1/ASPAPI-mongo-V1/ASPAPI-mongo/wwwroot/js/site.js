let dogsArray = []

let Dog = function (pBreed, pColor, pAge) {
    //this.Id = Math.random().toString(16).slice(5)  // tiny chance could get duplicates!
    this.breed = pBreed;
    this.color = pColor;
    this.age = pAge;
}


document.addEventListener("DOMContentLoaded", function () {

    $.get("api/Dog", function (data, status) {  // AJAX get
        dogsArray = data;  // put the returned server json data into our local array
      
        let table = document.getElementById('dogtable');
     
        let tr = document.createElement('tr');
        let td1 = document.createElement('td');
        td1.textContent = "Breed";
        tr.appendChild(td1);
        let td2 = document.createElement('td');
        td2.textContent = "Color";
        tr.appendChild(td2);
        let td3 = document.createElement('td');
        td3.textContent = "Age";
     
        tr.appendChild(td3);
       

        table.appendChild(tr);


            for (let dog of dogsArray) {
                let tr = document.createElement('tr');

                let td1 = document.createElement('td');
                td1.textContent = dog.breed;
                tr.appendChild(td1);

                let td2 = document.createElement('td');
                td2.textContent = dog.color;
                tr.appendChild(td2);

                let td3 = document.createElement('td');
                td3.textContent = dog.age;
                tr.appendChild(td3);

                table.appendChild(tr);
            }
        //myli.innerHTML = item.breed + ":  " + item.color + ":  " + item.age;
            
        });

});