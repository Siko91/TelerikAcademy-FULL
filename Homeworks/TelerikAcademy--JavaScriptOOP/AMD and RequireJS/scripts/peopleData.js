var peopleData = (function (count) {
     var data = [];
     var countOfPeople = count || 20;
     for (var i = 0; i < countOfPeople; i++) {
         var person = {};
         person.id = i + 1;
         person.name = "FName LName #" + (i + 1);
         person.age = Math.floor(Math.random() * 80) + 10;
         person.avatarUrl = "images/no-photo.png";
         data.push(person);
     }

     return data;
 } (80))