var fs = require('fs');
var Handlebars = require('handlebars');

function fixEntityTypes(entity){
    for(var property in entity.properties){
        if(!entity.properties[property].type){
            entity.properties[property].type = 'any';
        }else if(entity.properties[property].type==='array'){
            entity.properties[property].type = 'any';
        }else if(entity.properties[property].type==='object'){
            entity.properties[property].type = 'any';
        }else if(entity.properties[property].type==='integer'){
            entity.properties[property].type = 'number';
        }
    }    
}

function generateViewModelEntity(definitions,entity){
    var templateString = fs.readFileSync('templates/entity.template', 'utf8');
    var template = Handlebars.compile(templateString);
    var entityObject = definitions[entity];
    fixEntityTypes(entityObject);

    entityObject.entityName = entity;
    
    var templateOutput = template(entityObject);

    console.log(templateOutput);
}

fileName = 'swagger-api.json';
var swaggerApiString = fs.readFileSync(fileName, 'utf8');
var swaggerJsonData = JSON.parse(swaggerApiString);
var definitions = swaggerJsonData.definitions;

for(var entity in definitions){
    generateViewModelEntity(definitions,entity);
}


// generate models
// generate requests and responses

// generate service per controller

    // generate end points for controller

