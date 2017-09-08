from gurobipy import *

products = ["BRp", "HWp", "FWp", "SWp", "CSp", "MEPp", "UBERp"]

lines = ["BR1", "BR2", "HW1", "HW2", "FW", "SW", "CS",
         "MEP", "UBER1", "UBER2"]
modes = ['0', '1', '2', '3']

days = ["mon1", "tue1", "wed1", "thu1", "fri1", 
        "mon2", "tue2", "wed2", "thu2", "fri2",
        "mon3", "tue3", "wed3", "thu3", "fri3",
        "mon4", "tue4", "wed4", "thu4", "fri4"]

workers = ["Rick", "Morty", "Jerry", "Beth", "Summer", "Bird Person",
           "Tammy", "Squanchy", "Antsinmyeyes Johnson", "Sleepy Gary"]

skills = ["Frame", "Weld", "Plumb", "Wire", "Squanch"]

revenue = {"BRp" : 10, "HWp" : 7, "FWp" : 6, 
           "SWp" : 5, "CSp" : 3, "MEPp" : 14, "UBERp": 100}

line_modes = tuplelist([
    ('BR1', '0'), ('BR1', '1'), ('BR1', '2'), ('BR1', '3'),
    ('BR2', '0'), ('BR2', '1'), ('BR2', '2'), ('BR2', '3'),
    ('HW1', '0'), ('HW1', '1'), ('HW1', '2'), ('HW1', '3'),
    ('HW2', '0'), ('HW2', '1'), ('HW2', '2'), ('HW2', '3'),
    ('FW', '0'), ('FW', '1'), ('FW', '2'), ('FW', '3'),
    ('SW', '0'), ('SW', '1'), ('SW', '2'), ('SW', '3'),
    ('CS', '0'), ('CS', '1'), ('CS', '2'), ('CS', '3'),
    ('MEP', '0'), ('MEP', '1'), ('MEP', '2'), ('MEP', '3'),
    ('UBER1', '0'), ('UBER1', '1'), ('UBER1', '2'), ('UBER1', '3'),
    ('UBER2', '0'), ('UBER2', '1'), ('UBER2', '2'), ('UBER2', '3')
])

modes, production_yield = multidict({
    'BR1.0' : 0, 'BR1.1' : 1, 'BR1.2' : 2, 'BR1.3': 3, 'BR2.0' : 0, 'BR2.1' : 1, 'BR2.2' : 2,
    'BR2.3' : 3, 'HW1.0' : 0, 'HW1.1' : 1, 'HW1.2' : 2, 'HW1.3' : 3, 'HW2.0' : 0, 'HW2.1' : 1,
    'HW2.2' : 2, 'HW2.3' : 3, 'FW.0' : 0, 'FW.1' : 1, 'FW.2' : 2, 'FW.3' : 3, 'SW.0' : 0,
    'SW.1' : 2, 'SW.2' : 4, 'SW.3' : 6, 'CS.0' : 0, 'CS.1' : 2, 'CS.2' : 4, 'CS.3' : 6,
    'MEP.0' : 0, 'MEP.1' : .5, 'MEP.2' : 1, 'MEP.3' : 2, 'UBER1.0' : 0, 'UBER1.1' : .1,
    'UBER1.2' : .2, 'UBER2.0' : 0, 'UBER2.1' : .1, 'UBER2.2' : .2})

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

production_demand = {("Fri1", "BRp") : 4, ("Fr1", "HWp") : 8, ("Fri1", "MEPp") : 2}
QuickSum 
m = Model()

inventory = {}
revenue_inventory = {}
