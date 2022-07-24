const uri = 'api/basicmaths';
let todos: any = [];

function getItems() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function getFunctionExpression(expression:string) {
  fetch(`${uri}/getFunctionExpression/${expression}`, {
    method: 'GET',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    }
  })
    .then(response => response.json())
    .then(data => showFunctionExpression(data))
    .catch(error => console.error('Erro: ', error))
}

function addItem() {
  const addNameTextbox:any = document.getElementById('add-operationName');
  
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

function deleteItem(id:any) {
  fetch(`${uri}/${id}`, {
    method: 'DELETE'
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id:any) {
  const item = todos.find((item: { id: any; }) => item.id === id);
  var editOperationName:any = document.getElementById('edit-operationName');
  var editId:any = document.getElementById('edit-id');
  var editIsComplete:any = document.getElementById('edit-isComplete');
  var editForm:any = document.getElementById('editForm');

  editOperationName.value = item.operationName;
  editId.value = item.id;
  editIsComplete.checked = item.isComplete;
  editForm.style.display = 'block';
}

function updateItem() {
  var updateId:any = document.getElementById('edit-id');
  var updateIsComplete:any = document.getElementById('edit-isComplete');
  var updateOperationName:any = document.getElementById('edit-operationName');

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
    var getStyle:any = document.getElementById('editForm');
    getStyle.style.display = 'none';
}

function _displayCount(itemCount:any) {
  const name = (itemCount === 1 || itemCount === 0) ? 'Operation' : 'Operations';

  var getCounter:any = document.getElementById('counter');
  getCounter.innerText = `${itemCount} ${name}`;
}

function _displayItems(data:any) {
  const tBody:any = document.getElementById('todos');

  tBody.innerHTML = '';

  _displayCount(data.length);

  const button = document.createElement('button');

  data.forEach((item: { isComplete: boolean; id: any; operationName: string; }) => {
    let isCompleteCheckbox = document.createElement('input');
    isCompleteCheckbox.type = 'checkbox';
    isCompleteCheckbox.disabled = true;
    isCompleteCheckbox.checked = item.isComplete;

    let editButton:any = button.cloneNode(false);
    editButton.innerText = 'Edit';
    editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

    let deleteButton:any = button.cloneNode(false);
    deleteButton.innerText = 'Delete';
    deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

    let giveExpression:any = button.cloneNode(false);
    giveExpression.innerText = 'Give';
    giveExpression.setAttribute('onclick', `getExpression(${item.id})`);

    let giveFunction:any = button.cloneNode(false);
    giveFunction.innerText = 'Give Func' ;
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

function showFunctionExpression(data:any){
  var paragraf:any = document.getElementById("lala");
  paragraf.textContent = data.functionExpression;
  
}