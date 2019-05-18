var fs = require('fs');
var Handlebars = require('handlebars');

function fixEntityTypes(entity) {
    for (var property in entity.properties) {
        if (!entity.properties[property].type) {
            entity.properties[property].type = 'any';
        } else if (entity.properties[property].type === 'array') {
            entity.properties[property].type = 'any';
        } else if (entity.properties[property].type === 'object') {
            entity.properties[property].type = 'any';
        } else if (entity.properties[property].type === 'integer') {
            entity.properties[property].type = 'number';
        }
    }
}

function generateViewModelEntity(definitions, entity) {
    var templateString = fs.readFileSync('templates/entity.template', 'utf8');
    var template = Handlebars.compile(templateString);
    var entityObject = definitions[entity];
    fixEntityTypes(entityObject);
    entityObject.entityName = entity;
    var templateOutput = template(entityObject);
    templateOutput += "\n\n";
    return templateOutput;
}

function generateEndPoint(paths, path) {
    var templateString = fs.readFileSync('templates/endpoint.template', 'utf8');
    var template = Handlebars.compile(templateString);
    var endPoint = paths[path];

    endPoint.endPointName = path.split('/')[2];
    endPoint.controllerName = path.split('/')[1];
    var templateOutput = template(endPoint);
    templateOutput += "\n\n";
    return templateOutput;
}

function getServiceClassStart(controllerName) {
    var templateString = fs.readFileSync('templates/service-class-start.template', 'utf8');
    var template = Handlebars.compile(templateString);
    var data = {};
    data.controllerName = controllerName;
    var templateOutput = template(data);
    templateOutput += "\n\n";
    return templateOutput;
}

function getServiceClassStart(controllerName) {
    var templateString = fs.readFileSync('templates/service-class-start.template', 'utf8');
    var template = Handlebars.compile(templateString);
    var data = {};
    data.controllerName = controllerName;
    var templateOutput = template(data);
    templateOutput += "\n\n";
    return templateOutput;
}

function getServiceFileStart() {
    var templateString = fs.readFileSync('templates/service-file-start.template', 'utf8');
    templateString += "\n\n";
    return templateString;
}

function getServiceClassEnd() {
    var templateString = fs.readFileSync('templates/service-class-end.template', 'utf8');
    var template = Handlebars.compile(templateString);
    var data = {};
    var templateOutput = template(data);
    templateOutput += "\n\n";
    return templateOutput;
}

fileName = 'swagger-api.json';
var swaggerApiString = fs.readFileSync(fileName, 'utf8');
var swaggerJsonData = JSON.parse(swaggerApiString);
var definitions = swaggerJsonData.definitions;

var output = ""
output += getServiceFileStart();

for (var entity in definitions) {
    output += generateViewModelEntity(definitions, entity);
}

var controllersToProcess = ['Questions']

controllersToProcess.forEach(function(controller){
    output += getServiceClassStart(controller)
    for (var path in swaggerJsonData.paths) {
        if(path.startsWith('/'+controller+'/')){
            output += generateEndPoint(swaggerJsonData.paths, path);
        }
    }
    output += getServiceClassEnd()    
})
console.log(output);