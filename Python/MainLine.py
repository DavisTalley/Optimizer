
#
# FOR EACH LINE DESCIDE WHAT IS BEING PRODUCED 
# FOR EACH PRODUCT DECIDE THE RATE AT WHICH TO PRODUCE
# BECASUSE WE CANT CHOOSE THE RATE BASED SOLEY ON THE LINE


from gurobipy import *

# Q is the set of Processing Units Production Line 

#'BR1' = Bathroon 1, 'BR2' = Bathroon 2, 'HW1' Headwall 1, 'HW2' Headwall 2, 'FW' Foot Wall , 'SW' Sink Wall ,' MEP' Mecahnical Ele Plumpnig, 'CS' Chart Station , 'UBER1' Trailer Units, 'UBER2'
# PRODUCTION LINE NAMES 
x[('BR1', 'BR2', 'HW1', 'HW2', 'FW', 'SW','MEP', 'CS', 'UBER1', 'UBER2' )] = 1


# takt speed at which product can be produced  
# PRODCTS AND HOW FAST WE CAN PRODUCE
# PRODUCT TACT RATES 
#  IN UNITS - How many will come off the line in a given day
productTact, off, takt1, takt2, takt3  = multidict({
  "BGP":  [0,1,2,3],
  "BPR":  [0,1,2,3],
  "HEX":  [0,1,2,3],
  "HPR":  [0,1,2,3],
  "FPR":  [0,1,2,3],
  "SGP":  [0,2,4,6],
  "MEX":  [0,2,4,6],
  "MEP":  [0,0.25,0.5,1],
  "CHT":  [0,2,4,6],
  "UBR":  [0,0.1,0.2,0.25],
 })


skillSets, enable = multidict({
    "Frame": [0],
    "Plumber": [0],
    "Electrician": [0],
    "Welder": [0],
    "WaterBoy": [0],
})  


# NOT USE 
# Mq All Possible Run Mode for Each Production Line
# takt speed at which line run 
#  IN DAYS - How many will come off the line in a given day
# BR1.0 is no workers present of line is not causing resourece demand
# BR1.1 Contituients the tact of 1 which required 1-Plumber 2-Framer


productionModeRequirement, skill0, skill1, skill2, skill3, skill4 = multidict({
  "BR1.0":  [0,0,0,0,0],
  "BR1.1":  [0,1,2,3],
  "BR1.2":  [0,1,2,3],
  "BR1.3":  [0,1,2,3],
  "FW":   [0,2,4,6],
  "SW":   [0,2,4,6],
  "MEP":  [0,0.25,0.5,1],
  "CS":   [0,2,4,6],
  "UBER1":  [0,0.1,0.2,0.25],
  "UBER2":  [0,0.1,0.2,0.25]
  })



    

# Mq All Possible Run Mode for Each Production Line
# takt speed at which line run 
#  IN DAYS - How many will come off the line in a given day
productionModeSets, off, takt1, takt2, takt3  = multidict({
  "BR1":  ["BR1.0","BR1.1","BR1.2","BR1.3"],
  "BR2":  [0,1,2,3],
  "HW1":  [0,1,2,3],
  "HW2":  [0,1,2,3],
  "FW":   [0,2,4,6],
  "SW":   [0,2,4,6],
  "MEP":  [0,0.25,0.5,1],
  "CS":   [0,2,4,6],
  "UBER1":  [0,0.1,0.2,0.25],
  "UBER2":  [0,0.1,0.2,0.25]
  })


# Mq All Possible Run Mode for Each Production Line
# takt speed at which line run 
#  IN DAYS - How many will come off the line in a given day
productionModeSets, off, takt1, takt2, takt3  = multidict({
  "BR1":  [0,1,2,3],
  "BR2":  [0,1,2,3],
  "HW1":  [0,1,2,3],
  "HW2":  [0,1,2,3],
  "FW":   [0,2,4,6],
  "SW":   [0,2,4,6],
  "MEP":  [0,0.25,0.5,1],
  "CS":   [0,2,4,6],
  "UBER1":  [0,0.1,0.2,0.25],
  "UBER2":  [0,0.1,0.2,0.25]
  })





# P Set of Product by line
# For each line what product are produced on the line 
# PRODUCTS AND WHERE WE CAN PRODUCE THEM 
# BGP = Bathroon Gen. Purpose
# BPR = B Patient Room 
# HEX = HEad Wall Exam Room 
# HPR = HEad Wall Patient Room
# FPR = Footwall Patient Room
# SGP = Sink wall general purpose
# MEX = MEP Exam room  
# CHT = Chart Station 
# UBR  = Uber Container Module
# Production Location Ability  
productionLocationAbility = tuplelist([
('BGP', 'BR1'), ('BGP', 'BR2'), ('BPR', 'BR1'), ('BPR', 'BR2'),
('HEX', 'HW1'), ('HEX', 'HW2'), ('HPR', 'HW1'), ('HPR', 'HW2'),
('FPR', 'FW'), ('FPR', 'HW1'), ('FPR', 'HW2'), ('SGP', 'SW'),
('SGP', 'HW1'), ('SGP', 'HW2'), ('MEX', 'MEP'), ('CHT', 'CS'),
('CHT', 'SW'), ('CHT', 'FW'), ('CHT', 'HW1'), ('CHT', 'HW2'),
('UBR', 'UBER1'), ('UBR', 'UBER2')
])



# m Product Location and Tact Rate
# All RUN MODES
# DECISION VARIABLE - TO DETERMINE HOW OBJECT FUCNTION REACTS  
#   FACTOR 
#	ONE OPTION OF THE SET OF RUN MODE
#	AND IS DEFINCE BY PRODUCT PROCUDING 
#	THE LINE THAT THEY ARE PRODUCE ON 
#	AND THE RATE THAT THEY ARE BEING PRODUCED AT 




# dpt - DEMAND OF PRODUCT IN TIME 
# THis will ultimatly come from DB 
demandOutflow = {
  ('20170801', 'BGP'):   10,
  ('20170801', 'BPR'):   10,
  ('20170801', 'MEP'):   2,
  ('20170801', 'HEX'):   10,
  ('20170801', 'FPR'):   10
 }






# AT A Mq Processing Unit we can be running one production mode Only 
# AT EACH LOCATION WE CAN BE MAKING ONE PRODUICT AT ONE RATE
# 

# CONSTARIT 0 1 SUM OF 
# ONLY ONE THEREFORE THE SUM ON ALL RUN MODE MUST = 1 
# IF WE HAVE AS STEADY TACT RATE HOWEVER THE ARE TRYING TO DETEMINE THE TACT RATE FOR EACH LINE 
# ADJUSTED BY ADD MORE MAN POWER TO THE LINE THEREBY DECREASING NUM OF WORKS ON OTHER LINES  
# SUM OF EACH ROW DENOTEING ONE TACT MUST ALWAYS = ONE
# Ymt = 1


# Smt 1 >+ Y my  SWITCH COUNTER USED TO DETERMINEDIN STATRT UP COST
# 
# if and any time periond the runmode is different from previous period
# 
# 

# 