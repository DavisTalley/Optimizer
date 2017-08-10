from gurobipy import *

m = Model()

lm = m.addVar(vtype=GRB.BINARY, name="lineMode")

products = ["BR", "HW", "FW", "SW", "CS", "MEP", "UBER"]
lines = ["BR1", "BR2", "HW1", "HW2", "FW", "SW", "CS",
         "MEP", "UBER1", "UBER2"]
days = ["mon1", "tue1", "wed1", "thu1", "fri1", 
        "mon2", "tue2", "wed2", "thu2", "fri2",
        "mon3", "tue3", "wed3", "thu3", "fri3",
        "mon4", "tue4", "wed4", "thu4", "fri4"]
workers = ["Rick", "Morty", "Jerry", "Beth", "Summer", "Bird Person",
           "Tammy", "Squanchy", "Antsinmyeyes Johnson", "Sleepy Gary"]
skills = ["Frame", "Weld", "Plumb", "Wire", "Squanch"]

products, revenue = multidict({"BR" : 10, "HW" : 7, "FW" : 6, 
                               "SW" : 5, "CS" : 3, "MEP" : 14, "UBER": 100})

lines, mode = multidict({"BR1" : {'BR1.0', 'BR1.1', 'BR1.2', 'BR1.3'},
                        "BR2" : {'BR2.0', 'BR2.1', 'BR2.2', 'BR2.3'},
                        "HW1" : {'HW1.0', 'HW1.1', 'HW1.2', 'HW1.3'},
                        "HW2" : {'HW2.0', 'HW2.1', 'HW2.2', 'HW2.3'},
                        "FW" : {'FW.0', 'FW.2', 'FW.4', 'FW.6'},
                        "SW" : {'SW.0', 'SW.2', 'SW.4', 'SW.6'},
                        "CS" : {'CS.0', 'CS.2', 'CS.4', 'CS.6'},
                        "MEP" : {'MEP.0', 'MEP.0.25', 'MEP.0.5', 'MEP.1'},
                        "UBER1" : {'UBER1.0', 'UBER1.0.1', 'UBER1.0.2', 'UBER1.0.25'},
                        "UBER2" : {'UBER2.0', 'UBER2.0.1', 'UBER2.0.2', 'UBER2.0.25'}
                       })
 
workers_skills_table = {
    "Rick" : {"Frame": 1, "Plumb": 1},
    "Morty" : {"Weld": 1},
    "Jerry" : {"Frame": 1, "Weld": 1, "Plumb": 1, "Wire": 1,},
    "Beth" : {"Wire": 1, "Weld": 1},
    "Summer" : {"Wire": 1},
    "Bird Person" : {"Frame": 1, "Plumb": 1, "Wire": 1},
    "Tammy" : {"Frame": 1, "Plumb": 1},
    "Squanchy" : {"Weld": 1, "Squanch": 1},
    "Antsinmyeyes Johnson" : {"Plumb": 1},
    "Sleepy Gary" : {"Plumb": 1}
}

production_demand = {("Fri1", "BR") : 4, ("Fr1", "HW") : 8, ("Fri1", "MEP") : 2}

print(skills)