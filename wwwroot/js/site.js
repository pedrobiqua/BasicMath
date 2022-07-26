"use strict";
const uri = 'api/basicmaths';
let todos = [];
function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}
function getFunctionExpression(expression) {
    fetch(`${uri}/getFunctionExpression/${expression}`, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => showFunctionExpression(data))
        .catch(error => console.error('Erro: ', error));
}
function addItem() {
    const addNameTextbox = document.getElementById('add-operationName');
    const item = {
        isComplete: false,
        operationName: addNameTextbox.value.trim()
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
        getItems();
        addNameTextbox.value = '';
    })
        .catch(error => console.error('Unable to add item.', error));
}
function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}
function displayEditForm(id) {
    const item = todos.find((item) => item.id === id);
    var editOperationName = document.getElementById('edit-operationName');
    var editId = document.getElementById('edit-id');
    var editIsComplete = document.getElementById('edit-isComplete');
    var editForm = document.getElementById('editForm');
    editOperationName.value = item.operationName;
    editId.value = item.id;
    editIsComplete.checked = item.isComplete;
    editForm.style.display = 'block';
}
function updateItem() {
    var updateId = document.getElementById('edit-id');
    var updateIsComplete = document.getElementById('edit-isComplete');
    var updateOperationName = document.getElementById('edit-operationName');
    const itemId = updateId.value;
    const item = {
        id: parseInt(itemId, 10),
        isComplete: updateIsComplete.checked,
        operationName: updateOperationName.value.trim()
    };
    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));
    closeInput();
    return false;
}
function closeInput() {
    var getStyle = document.getElementById('editForm');
    getStyle.style.display = 'none';
}
function _displayCount(itemCount) {
    const name = (itemCount === 1 || itemCount === 0) ? 'Operation' : 'Operations';
    var getCounter = document.getElementById('counter');
    getCounter.innerText = `${itemCount} ${name}`;
}
function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';
    _displayCount(data.length);
    const button = document.createElement('button');
    data.forEach((item) => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);
        let giveExpression = button.cloneNode(false);
        giveExpression.innerText = 'Give';
        giveExpression.setAttribute('onclick', `getExpression(${item.id})`);
        let giveFunction = button.cloneNode(false);
        giveFunction.innerText = 'Give Func';
        giveFunction.setAttribute('onclick', `getFunctionExpression("${item.operationName}")`);
        let tr = tBody.insertRow();
        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);
        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(item.operationName);
        td2.appendChild(textNode);
        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);
        let td4 = tr.insertCell(3);
        td4.appendChild(giveFunction);
    });
    todos = data;
}
function showFunctionExpression(data) {
    var paragraf = document.getElementById("lala");
    paragraf.textContent = data.functionExpression;
}
