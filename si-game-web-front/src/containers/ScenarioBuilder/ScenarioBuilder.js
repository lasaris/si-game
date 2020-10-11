import React, { Component } from 'react';
import IntermissionModule from '../../components/Scenario/ScenarioModules/IntermissionModule/IntermissionModule';
import IntermissionFrameComponent from '../../components/Scenario/ScenarioComponents/IntermissionFrameComponent'
import IntermissionModuleTest from '../../conTest/IntermissionModuleTest';
import Form from "@rjsf/material-ui";
import { PictureAsPdf } from '@material-ui/icons';

class ScenarioBuilder extends Component {
    state = {
        firstScreen: true,
        password: '',
        gameId: '',
        loadGameSchema: {
          title: "Load your game",
          type: "object",
          required: [
            "gameId",
            "password"
          ],
          properties: {
            gameId: {
              type: "string",
              title: "Game id"
            },
            password: {
              type: "string",
              title: "Password"
            }
          }
        },
        createNewGameSchema: {
          title: "Create new game",
          type: "object",
          required: [
            "password"
          ],
          properties: {
            password: {
              type: "string",
              title: "Create password"
            }
          }          
        },
        uiPasswordSchema: {
          password: {
            "ui:widget": "password"
          }
        },
        formData: {},
        currentIdData: {
          currentFreeModuleId: 1,
          currentFreeComponentId: 1,
          currentFreeActionId: 1,
        },
        schema: {
          title: "Scenario builder",
          type: "object",
          required: [
            "visibleModuleIdStart"
          ],
          properties: {
            visibleModuleIdStart: {
              type: "number",
              enum: [""],
              title: "Visible module id from start"
            },
            intermissionModules: {
              title: "Intermission modules",
              type: "array",
              maxItems: 1,
              items: {
                "$ref": "#/definitions/intermissionModule"
              }
            },
            emailModules: {
              title: "Email module",
              type: "array",
              maxItems: 1,
              items: {
                "$ref": "#/definitions/emailModule"
              }
            },
            browserModules: {
              title: "Browser module",
              type: "array",
              maxItems: 1,
              items: {
                "$ref": "#/definitions/browserModule"
              }
            }
          },
          definitions: {
            componentId: {
              type: "number",
              title: "Component id",
              readOnly: true
            },
            actionId: {
              type: "number",
              title: "Action id",
              readOnly: true
            },
            moduleId: {
              type: "number",
              title: "Module id",
              readOnly: true
            },
            intermissionModule: {
              type: "object",
              title: "Intermission module",
              properties: {
                moduleId: {
                  $ref: "#/definitions/moduleId"
                },
                currentIntermissionFrameId: {
                  type: "number",
                  title: "Current intermission frame id",
                  enum: [""]
                },
                intermissionFrames: {
                  type: "array",
                  items: {
                    "$ref": "#/definitions/intermissionFrame"
                  }
                }
              }
            },
            intermissionFrame: {
              type: "object",
              title: "Intermission frame",
              properties: {
                componentId: {
                  $ref: "#/definitions/componentId"
                },
                frameType: {
                  type: "string",
                  enum: [
                    "Text",
                    "Question",
                    "Multichoice question",
                    "User input"
                  ]
                }
              },
              dependencies: {
                frameType: {
                  oneOf: [
                    {
                      properties: {
                        frameType: {
                          enum: ["Text"]
                        },
                        text: {
                          type: "string",
                          title: "Text"
                        },
                        buttons: {
                          type: "array",
                          title: "Button",
                          maxItems: 1,
                          items:{
                            $ref: "#/definitions/button"
                          }
                        }
                      }
                    },
                    {
                      properties: {
                        frameType: {
                          enum: ["Question"]
                        },
                        text: {
                          type: "string",
                          title: "Text"
                        },
                        questions: {
                          type: "array",
                          items:{
                            "$ref": "#/definitions/question"
                          }
                        },
                        buttons: {
                          type: "array",
                          title: "Button",
                          maxItems: 1,
                          items:{
                            $ref: "#/definitions/button"
                          }
                        }                       
                      }
                    },
                    {
                      properties: {
                        frameType: {
                          enum: ["Multichoice question"]
                        },
                        text: {
                          type: "string",
                          title: "Text"
                        },
                        questions: {
                          type: "array",
                          items:{
                            "$ref": "#/definitions/question"
                          }
                        },
                        buttons: {
                          type: "array",
                          title: "Button",
                          maxItems: 1,
                          items:{
                            $ref: "#/definitions/button"
                          }
                        }
                      }
                    },
                    {
                      properties: {
                        frameType: {
                          enum: ["User input"]
                        },
                        text: {
                          type: "string",
                          title: "Text"
                        },
                        buttons: {
                          type: "array",
                          title: "Button",
                          maxItems: 1,
                          items:{
                            $ref: "#/definitions/button"
                          }
                        }
                      }
                    }
                  ]
                }
              }
            }, 
            question: {
              type: "object",
              title: "Question",
              properties: {
                componentId: {
                  $ref: "#/definitions/componentId"
                },
                text: {
                  type: "string",
                  Title: "Question text"
                },
                options: {
                  type: "array",
                  items: {
                    "$ref": "#/definitions/option"
                  }
                }
              }
            },
            option: {
              type: "object",
              properties: {
                componentId: {
                  $ref: "#/definitions/componentId"
                },
                text: {
                  type: "string",
                  title: "Option"
                }
              }
            },
            emailModule: {
              type: "object",
              title: "",
              properties: {
                moduleId: {
                  $ref: "#/definitions/moduleId"
                },
                newEmailSubject: {
                  type: "string",
                  title: "New email subject"
                },
                sentEmails: {
                  type: "array",
                  items: {
                    $ref: "#/definitions/email"
                  }
                },
                receivedEmails: {
                  type: "array",
                  items: {
                    $ref: "#/definitions/email"
                  }
                }
              }
            },
            email: {
              type: "object",
              title: "Email component",
              properties: {
                componentId: {
                  $ref: "#/definitions/componentId"
                },
                sender: {
                  type: "string",
                  title: "Sender"
                },
                subject: {
                  type: "string",
                  title: "Subject"
                },
                date: {
                  type: "string",
                  format: "date-time",
                  title: "Date"
                },
                contentHeader: {
                  type: "string",
                  title: "Content header"
                },
                contentFooter: {
                  type: "string",
                  title: "Content footer"
                },
                active: {
                  type: "boolean",
                  title: "Is email active in the beggining?"
                },
                emailParagraphs: {
                  type: "array",
                  title: "Email content paragraphs",
                  items: {
                    type: "string",
                    title: "Paragraph"
                  }
                }
              }
            },
            browserModule: {
              type: "object",
              title: "",
              properties: {
                moduleId: {
                  $ref: "#/definitions/moduleId"
                },
                searchingMinigames: {
                  type: "array",
                  maxItems: 1,
                  title: "Searching minigames",
                  items:{
                    $ref: "#/definitions/searchingMinigame"
                  }
                }
              }
            },
            searchingMinigame: {
              type: "object",
              title: "Searching minigame",
              properties: {
                componentId: {
                  $ref: "#/definitions/componentId"
                },
                solution: {
                  type: "string",
                  title: "Solution"
                },
                height: {
                  type: "number",
                  title: "Height"
                },
                width: {
                  type: "number",
                  title: "Width"
                },
                words: {
                  type: "array",
                  title: "Words",
                  items: {
                    type: "object",
                    title: "Word",
                    properties: {
                      value: {
                        type: "string",
                        title: "Value"
                      },
                      componentId: {
                        $ref: "#/definitions/componentId"
                      }
                    }
                  }
                }
              }
            },
            button: {
              type: "object",
              title: "Button",
              properties: {
                componentId: {
                  $ref: "#/definitions/componentId"
                },
                buttonText: {
                  type: "string",
                  title: "Button text"
                },
                sendEmailToPlayerActions: {
                  type: "array",
                  items: {
                    "$ref": "#/definitions/sendEmailToPlayerAction"
                  }
                },
                switchIntermissionFramesActions: {
                  type: "array",
                  items: {
                    "$ref": "#/definitions/switchIntermissionFrameAction"
                  }
                },
                updateMainVisibleModuleActions: {
                  type: "array",
                  items: {
                    "$ref": "#/definitions/updateMainVisibleModuleAction"
                  }
                },
                addRecipientToNewEmailActions: {
                  type: "array",
                  items: {
                    "$ref": "#/definitions/addRecipientToNewEmailAction"
                  }
                }
              }
            },
            sendEmailToPlayerAction: {
              type: "object",
              title: "Send email to player",
              properties: {
                actionId: {
                  $ref: "#/definitions/actionId"
                },
                emailComponentId: {
                  type: "number",
                  title: "Email component id",
                  enum: [""]
                }
              }
            },
            switchIntermissionFrameAction: {
              type: "object",
              title: "Switch intermission frame action",
              properties: {
                actionId: {
                  $ref: "#/definitions/actionId"
                },
                newIntermissionFrameId: {
                  type: "number",
                  title: "New intermission frame id",
                  enum: [""]
                },
                intermissionModuleId: {
                  type: "number",
                  title: "Intermission module id",
                  enum: [""]
                }
              }
            },
            updateMainVisibleModuleAction: {
              type: "object",
              title: "Update main visible module action",
              properties: {
                actionId: {
                  $ref: "#/definitions/actionId"
                },
                newMainVisibleModuleId: {
                  type: "number",
                  title: "New main visible module id",
                  enum: [""]
                }
              }
            },
            addRecipientToNewEmailAction: {
              type: "object",
              title: "Add recipient to new email",
              properties: {
                actionId: {
                  $ref: "#/definitions/actionId"
                },
                RecipientComponentId: {
                  type: "number",
                  title: "Recipient component id",
                  enum: [""]
                }
              }
            }
          }
        }
      }

      findValues(obj, key){
        return this.findValuesHelper(obj, key, []);
      }
      
      findValuesHelper(obj, key, list) {
        if (!obj) return list;
        if (obj instanceof Array) {
          for (var i in obj) {
              list = list.concat(this.findValuesHelper(obj[i], key, []));
          }
          return list;
        }
        if (obj[key]) list.push(obj[key]);
      
        if ((typeof obj == "object") && (obj !== null) ){
          var children = Object.keys(obj);
          if (children.length > 0){
            for (i = 0; i < children.length; i++ ){
                list = list.concat(this.findValuesHelper(obj[children[i]], key, []));
            }
          }
        }
        return list;
      }

      assignModuleIdToModule(module){
        if(module !== undefined && (module.moduleId === null || module.moduleId === undefined)){
          module.moduleId = this.state.currentIdData.currentFreeModuleId;
          this.state.currentIdData.currentFreeModuleId++;
        }
      }

      assignComponentIdToComponent(component){
        if(component === undefined || component === null){
          return;
        }
        if(component.componentId === null || component.componentId === undefined){
          console.log("heree");
          component.componentId = this.state.currentIdData.currentFreeComponentId;
          this.state.currentIdData.currentFreeComponentId++;
        }
      }

      assignComponentIdToComponentList(listOfComponents){
        if(listOfComponents === undefined || listOfComponents === null){
          return;
        }
        for(let component of listOfComponents){
          console.log(component);
          this.assignComponentIdToComponent(component);
        }
      }

      onChange = (e) => {
        const formData = JSON.parse(JSON.stringify(e.formData));
        let schema = JSON.parse(JSON.stringify(this.state.schema));
        schema.properties.visibleModuleIdStart.enum = [];
        this.assignComponentIdToComponentList(this.findValues(formData, "intermissionFrames").flat(1));
        this.assignComponentIdToComponentList(this.findValues(formData, "questions").flat(1));
        this.assignComponentIdToComponentList(this.findValues(formData, "options").flat(1));
        this.assignComponentIdToComponentList(this.findValues(formData, "buttons").flat(1));
        this.assignComponentIdToComponentList(this.findValues(formData, "newEmailButtons").flat(1));
        this.assignComponentIdToComponentList(this.findValues(formData, "sentEmails").flat(1));
        this.assignComponentIdToComponentList(this.findValues(formData, "receivedEmails").flat(1));
        this.assignComponentIdToComponentList(this.findValues(formData, "searchingMinigames").flat(1));
        this.assignComponentIdToComponentList(this.findValues(formData, "words").flat(1));

        if(formData.intermissionModules !== undefined && formData.intermissionModules.length > 0){
          this.assignModuleIdToModule(formData.intermissionModules[0]);
          schema.properties.visibleModuleIdStart.enum.push(formData.intermissionModules[0].moduleId);
          if(formData.intermissionModules[0].intermissionFrames !== undefined && formData.intermissionModules[0].intermissionFrames.length > 0){
            schema.definitions.intermissionModule.properties.currentIntermissionFrameId.enum 
            = formData.intermissionModules[0].intermissionFrames.map(item => item.componentId);    
          }
        }
        if(formData.emailModules !== undefined && formData.emailModules.length > 0){
          this.assignModuleIdToModule(formData.emailModules[0]);
          schema.properties.visibleModuleIdStart.enum.push(formData.emailModules[0].moduleId);
        }
        if(formData.browserModules !== undefined && formData.browserModules.length > 0){
          this.assignModuleIdToModule(formData.browserModules[0]);
          schema.properties.visibleModuleIdStart.enum.push(formData.browserModules[0].moduleId);
        }
        
        this.setState({
          formData,
          schema
        });
      }

      // blur = (id) => {
      //   console.log(id);
      //   if(id !== undefined){
      //     let splittedId = id.split("_");
      //     const lastElement = splittedId[splittedId.length - 1];
      //     const prelastElement = splittedId[splittedId.length - 2];
      //     console.log("outside if");
      //     if(lastElement === "currentIntermissionFrameId" && this.state.formData.intermissionModules[prelastElement].intermissionFrames){
      //       let schema = JSON.parse(JSON.stringify(this.state.schema));
      //       console.log("inside if");
      //       console.log(this.state.formData.intermissionModules[prelastElement].intermissionFrames.map(item => item.componentId));
      //       schema.definitions.intermissionModule.properties.currentIntermissionFrameId.enum 
      //         = this.state.formData.intermissionModules[prelastElement].intermissionFrames.map(item => item.componentId);
      //       this.setState({
      //         schema
      //       });
      //     }
      //   }
      // }

      submitGamePassword({formData}, e){
        this.setState({password: formData.password, firstScreen: false});
      }

      submitGameLoadingForm({formData}, e){
        var xhr = new XMLHttpRequest();
        xhr.responseType = 'json';
        xhr.addEventListener('load', () => {
          console.log(xhr.response);
          this.setState({formData: xhr.response.formData, schema: xhr.response.schema, currentIdData: xhr.response.currentIdData, firstScreen: false, newScenario: false});
          console.log(this.state.formData.visibleModuleIdStart);
        })
        xhr.open('GET', 'https://localhost:44316/scenario/get?gameId=' + formData.gameId + '&password=' + formData.password);
        this.setState({password: formData.password, gameId: formData.gameId});
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.send();
      }

    render() {
        const log = (type) => console.log.bind(console, type);
        const onSubmit = ({formData}, e) => 
        {
          var xhr = new XMLHttpRequest();
          xhr.addEventListener('load', () => {
            this.setState({gameId: xhr.response})
          })
          xhr.open('POST', 'https://localhost:44316/scenario/add?password=' + this.state.password + '&gameId=' + this.state.gameId);
          xhr.setRequestHeader("Content-Type", "application/json");
          xhr.send(JSON.stringify({formData, schema: this.state.schema, currentIdData: this.state.currentIdData }));
        }
        
        return (
          <div style={{margin:128}}>
            {this.state.firstScreen ? 
              <div>
                <div>
                  <Form schema={this.state.loadGameSchema}
                        uiSchema={this.state.uiPasswordSchema}
                        onSubmit={this.submitGameLoadingForm.bind(this)}>
                  </Form>
                </div>
                <div style={{"margin-top": 128}}>
                  <Form schema={this.state.createNewGameSchema}
                        uiSchema={this.state.uiPasswordSchema}
                        onSubmit={this.submitGamePassword.bind(this)}>
                  </Form>
                </div>
              </div>
              : <Form schema={this.state.schema}
              formData={this.state.formData}o
              onChange={this.onChange.bind(this)}
              onSubmit={onSubmit.bind(this)}
              onError={log("errors")}
              showErrorList={false}></Form>}
              <div>
                {this.state.gameId}
              </div>
          </div>
        );
    }
}

export default ScenarioBuilder;