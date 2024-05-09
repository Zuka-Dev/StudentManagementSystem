/*
fetch from DB and append to the table created

Get Form data

Make  a post request to the backend

//Subsequent

- Ability to search for student
- Soft delete, Created and Updated
-Learn Dapper.
- Carry Out Update and Delete Operations later.
*/
const loadingMessage = document.getElementById("loading-message");
loadingMessage.style.display = "block";
const tableBody = document.querySelector("#studentTable tbody");

//loading state for the fetch
let isLoading = false;
getAllDepts();
document.addEventListener("DOMContentLoaded", function () {
  getStudents();
});

let data = [];
const getStudents = async () => {
  try {
        document.getElementById("success").style.visibility = "hidden";

    const response = await fetch("https://localhost:7059/api/Student");
    const result = await response.json();
    data = result;
    // console.log(data);
    createStudentRecords(); // Call the function after data is fetched
  } catch (error) {
    console.error("Error fetching data:", error);
  } finally {
    // Hide loading message when data fetching is done
    loadingMessage.style.display = "none";
  }
};

function createStudentRecords() {
  data.forEach(async (student) => {
    // use async here
    const row = document.createElement("tr");
    var dept = await getDepartment(student.departmentId);
    // console.log(dept)
    row.innerHTML = `
                <td>${student.registrationNumber}</td>
                <td>${student.firstName}</td>
                <td>${student.middleName}</td>
                <td>${student.lastName}</td>
                <td>${dept.name}</td>
            `;
    //Fix dept Bug
    tableBody.appendChild(row);
  });
}
async function getDepartment(id) {
  try {
    const response = await fetch("https://localhost:7059/api/Department/" + id);
    const result = await response.json();
    return result;
  } catch (error) {
    console.error(error);
  }
}

const studentForm = document.getElementById("studentForm");

studentForm.addEventListener("submit", async (e) => {
  e.preventDefault();
  isLoading = true;
  var button = document.getElementById("submit-btn");
  button.disabled = true;
  // button.classList.add("disabled");
  // Fetch the values of the form fields
  const firstName = document.getElementById("firstName").value;
  const lastName = document.getElementById("lastName").value;
  const middleName = document.getElementById("middleName").value;
  const departmentId = document.getElementById("departmentId").value;
  addStudent(firstName, lastName, middleName, departmentId);
  firstName.value = "";
  lastName.value = "";
  middleName.value = "";
  isLoading = false;
});

async function addStudent(firstName, lastName, middleName, departmentId) {
  try {
    const response = await fetch("https://localhost:7059/api/Student", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        firstName: firstName,
        middleName: middleName,
        lastName: lastName,
        departmentId: departmentId,
      }),
    });
    const result = await response.json();
    console.log(result);
  } catch (error) {
    console.error(error);
  } finally {
    document.getElementById("success").style.visibility = "visible";
    isLoading = false;
    const button = document.getElementById("submit-btn");
    button.disabled = false;
    tableBody.innerHTML = "";
    getStudents();
  }
}

async function getAllDepts() {
  try {
    var response = await fetch("https://localhost:7059/api/Department");
    var result = await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
  }
  var depts = document.getElementById("departmentId");
  console.log(result);
  result.forEach((item) => {
    var option = document.createElement("option");
    option.value = item.id;
    option.textContent = item.name;
    depts.appendChild(option);
  });
}
//validate at backend

// async function onDelete(){
//     const id = document.getElementById("id").value;
//     console.log(id);
//     try {
//         const response = await fetch("https://localhost:7059/api/Student/" + id, {
//         method: "DELETE",
//         });
//         const result = await response.json();
//         console.log(result);
//         window.location.reload();
//     } catch (error) {
//         console.error(error);
//     }
// }
