using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
                // Questions related to CourseId
                new Question
                {
                    Id = 1,
                    CourseId = 1,
                    Description = "What is the basic unit of life?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 2,
                    CourseId = 1,
                    Description = "Which organelle is known as the powerhouse of the cell?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 3,
                    CourseId = 2,
                    Description = "What is the function of ribosomes?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 4,
                    CourseId = 2,
                    Description = "What is the role of the cell membrane?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 5,
                    CourseId = 2,
                    Description = "What is osmosis?",
                    TestId = null,
                    SubCategoryId = null,
                    BlogId = null
                },

                // Questions related to SubCategoryId
                new Question
                {
                    Id = 6,
                    SubCategoryId = 1,
                    Description = "What is the primary function of the digestive system?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 7,
                    SubCategoryId = 1,
                    Description = "How does the body absorb nutrients?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 8,
                    SubCategoryId = 2,
                    Description = "What are the main components of the digestive system?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 9,
                    SubCategoryId = 2,
                    Description = "What is the role of enzymes in digestion?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 10,
                    SubCategoryId = 3,
                    Description = "What is the process of peristalsis?",
                    TestId = null,
                    CourseId = null,
                    BlogId = null
                },

                // Questions related to BlogId
                new Question
                {
                    Id = 11,
                    BlogId = 1,
                    Description = "What are the key structures of the human body?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },
                new Question
                {
                    Id = 12,
                    BlogId = 1,
                    Description = "How does the muscular system work?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },
                new Question
                {
                    Id = 13,
                    BlogId = 2,
                    Description = "What is the importance of studying anatomy?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },
                new Question
                {
                    Id = 14,
                    BlogId = 2,
                    Description = "What are the different systems of the human body?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },
                new Question
                {
                    Id = 15,
                    BlogId = 3,
                    Description = "What role does the nervous system play in body functions?",
                    TestId = null,
                    CourseId = null,
                    SubCategoryId = null
                },

                // Questions related to TestId
                new Question
                {
                    Id = 16,
                    TestId = 1,
                    Description = "What is the primary function of red blood cells?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 17,
                    TestId = 1,
                    Description = "How does the immune system protect the body?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 18,
                    TestId = 2,
                    Description = "What are the stages of the cell cycle?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 19,
                    TestId = 2,
                    Description = "What is apoptosis?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },
                new Question
                {
                    Id = 20,
                    TestId = 2,
                    Description = "What role does DNA play in inheritance?",
                    CourseId = null,
                    SubCategoryId = null,
                    BlogId = null
                },


                 // real data 
                 new Question
                 {
                     Id = 21,
                     TestId = 4,
                     Description = "To manually assess a patient's lower extremity circulation, a physical therapist should palpate the patient's peripheral pulse at which of the following locations?",
                     CourseId = null,
                     SubCategoryId = 36,
                     BlogId = null
                 },


              new Question
              {
                  Id = 22,
                  TestId = 4,
                  Description = "A patient has difficulty palpating the carotid pulse during exercise. The patient should be instructed in alternate methods of self-monitoring, because repeated palpation is likely to result in:",
                  CourseId = null,
                  SubCategoryId = 36,
                  BlogId = null
              },

                 new Question
                 {
                     Id = 23,
                     TestId = 4,
                     Description = "A physical therapist is walking down an isolated hospital staircase. The therapist sees a middle-aged adult lying on the landing and determines that the adult is unresponsive. What should the therapist do NEXT?",
                     CourseId = null,
                     SubCategoryId = 36,
                     BlogId = null
                 },
        // Seed Question 24
        new Question
        {
            Id = 24,
            TestId = 4,
            Description = "A patient reports a 2-week history of left upper abdominal quadrant pain, left flank pain, and mid-back pain as a result of a motor vehicle accident. The patient also reports being fatigued and generally not feeling well. Which of the following differential diagnoses would MOST likely account for the patient's symptoms?",
            CourseId = null,
            SubCategoryId = 36,
            BlogId = null
        },

                new Question
                {
                    Id = 25,
                    TestId = 4,
                    Description = "Clubbing of the fingers is MOST associated with which of the following conditions?",
                    CourseId = null,
                    SubCategoryId = 36,
                    BlogId = null
                },

new Question
{
    Id = 26,
    TestId = 4,
    Description = "During initial examination of a patient, a physical therapist notices severe clubbing of the patient's fingernails. The therapist should further investigate for the presence of signs and symptoms associated with which of the following conditions?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 27,
    TestId = 4,
    Description = "What precautions should a physical therapist observe when working with a patient infected with methicillin-resistant Staphylococcus aureus?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 28,
    TestId = 4,
    Description = "When examining a patient with a history of alcohol abuse, a physical therapist notes that the patient demonstrates fine resting tremors and hyperactive reflexes. The patient reports frequent right upper quadrant pain. Which of the following additional signs is MOST likely to be present?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 29,
    TestId = 4,
    Description = "Which of the following signs and symptoms are MOST characteristic of a patient with metabolic syndrome?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 30,
    TestId = 4,
    Description = "During an examination, a physical therapist finds that a patient with chronic obstructive pulmonary disease has a weak wet cough. Which of the following techniques is MOST appropriate to help this patient clear secretions?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 31,
    TestId = 4,
    Description = "Increased residual volume is LEAST likely to be a finding in pulmonary function testing of a patient with which of the following conditions?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 32,
    TestId = 4,
    Description = "Which of the following combinations of measures is the MOST useful for determining changes in status in a patient who has chronic obstructive pulmonary disease and emphysema?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 33,
    TestId = 4,
    Description = "A patient with a recent total knee arthroplasty and a new diagnosis of hiatal hernia is concerned about the exercise program. Which of the following responses by the physical therapist would be MOST appropriate?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},


new Question
{
    Id = 34,
    TestId = 4,
    Description = "Which of the following hernias is MOST likely to cause shoulder pain?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 35,
    TestId = 4,
    Description = "A patient who has a hiatal hernia is receiving physical therapy. Which of the following exercises would MOST likely worsen the symptoms related to the hernia?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 36,
    TestId = 4,
    Description = "A patient reports multiple myalgias, fatigue, weight gain despite decreased food intake, and frequently feeling cold. The physical therapist should expect information from which of the following tests to be MOST helpful in managing the patient's care?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 37,
    TestId = 4,
    Description = "Which of the following factors is considered to be a primary risk factor for atherosclerosis?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 38,
    TestId = 4,
    Description = "Which of the following endocrine glands regulates sexual development?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 39,
    TestId = 4,
    Description = "Which of the following is the MOST likely hormonal response in reaction to a stressful stimulus?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 40,
    TestId = 4,
    Description = "A patient with syndrome of inappropriate antidiuretic hormone secretion (SIADH) would MOST likely have complications involving which of the following systems?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},



//    cardio & chest test 2 "premium"
new Question
{
    Id = 41,
    TestId = 5,
    Description = "A patient has aspiration precautions. Which of the following factors is MOST likely to affect the patient's condition?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 42,
    TestId = 5,
    Description = "A physical therapist examines the output from a single lead electrocardiogram of a patient with atrioventricular heart block. The defining characteristic of first-degree atrioventricular heart block is:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 43,
    TestId = 5,
    Description = "A patient's electrocardiogram shows a new ST-segment displacement from baseline and a sinus rhythm of 70 bpm. What is the MOST likely diagnosis?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 44,
    TestId = 5,
    Description = "A patient who is transported to the physical therapy department in a wheelchair reports severe, bilateral lower extremity pain. A purple discoloration of both feet is observed. The pain is relieved when the patient's feet are raised just above the horizontal plane. These signs are MOST indicative of:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 45,
    TestId = 5,
    Description = "A patient with peripheral vascular disease comes to physical therapy for evaluation of leg pain that gets worse when walking. The patient will MOST likely also have:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}, new Question
{
    Id = 46,
    TestId = 5,
    Description = "A physical therapist reviews the medical record of a patient diagnosed with peripheral vascular disease prior to initiating treatment. Which objective finding would most severely limit the patient's ability to participate in an exercise program?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 47,
    TestId = 5,
    Description = "A patient with the ulcer shown in the photograph is unable to perceive a 5.07-gauge (10-g) monofilament applied to the sole of the foot. Which of the following ulcer types is MOST likely present?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 49,
    TestId = 5,
    Description = "A patient who has lower extremity claudication is exercising to the point of symptom production. The skin on the distal aspect of the patient's lower extremity is MOST likely to display which of the following findings?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 50,
    TestId = 5,
    Description = "A patient has an aching, cramping sensation in the posterior lower legs bilaterally that occurs during walking and is relieved by rest. The patient's feet are pale and cool to the touch. The popliteal and pedal pulses are absent. The patient has full range of motion of the ankles and knee, and Normal (5/5) strength in the tibialis anterior and Good (4/5) strength in the gastrocnemius and soleus bilaterally. The MOST likely cause of this patient's pain is:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 51,
    TestId = 5,
    Description = "A patient is in good health except for hypertension that is controlled with a beta-blocker. What is the BEST means of monitoring the patient's cardiovascular tolerance?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 52,
    TestId = 5,
    Description = "A physical therapist working with a patient who is borderline hypotensive can minimize orthostatic hypotension by:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 53,
    TestId = 5,
    Description = "A physical therapist plans to use a tilt table for a patient who is having difficulty tolerating upright sitting position. The therapist should stop inclining the tilt table if the patient experiences which of the following signs and symptoms?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 54,
    TestId = 5,
    Description = "Which of the following signs is MOST likely to be present in a patient who has been experiencing chronic diarrhea?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 55,
    TestId = 5,
    Description = "A physical therapist is examining the feet of a patient with type 2 diabetes. Which of the following tests is BEST to determine the patient's risk for developing foot ulceration?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 56,
    TestId = 5,
    Description = "A patient suspected of having hypoglycemia is MOST likely to show which of the following signs?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 57,
    TestId = 5,
    Description = "A physical therapist is monitoring the exercise of a patient who has type 1 diabetes. The patient's blood glucose level would be BEST for safe exercise at which of the following values?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 58,
    TestId = 5,
    Description = "A physical therapist has been asked to speak to a group of senior citizens regarding the benefits of exercise. The therapist should instruct the group that exercise has the greatest effect on which of the following endocrine disorders?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 59,
    TestId = 5,
    Description = "A patient who has type 2 diabetes mellitus is starting an aerobic exercise program. Which of the following effects is MOST expected with continued adherence to the exercise program?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 60,
    TestId = 5,
    Description = "During an initial evaluation, which of the following tests is MOST likely to identify an abnormal finding for a patient who has acute right-sided heart failure?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},


// cardio exam 3 


new Question
{
    Id = 61,
    TestId = 6,
    Description = "An inpatient is referred to physical therapy after undergoing coronary artery bypass surgery 5 days ago. The patient's medical history includes hypertension, hypercholesterolemia, and type 2 diabetes. Which of the following sets of factors should a physical therapist consider when developing a plan of care?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 62,
    TestId = 6,
    Description = "A woman has been walking on a treadmill for 10 minutes at 3.5 miles (5.6 km) per hour and 0° elevation when she reports a new onset of midthoracic back pain, aching in the right biceps muscle, fatigue, weakness, and nausea. Which system is MOST likely implicated?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 63,
    TestId = 6,
    Description = "Which of the following descriptions BEST characterizes stable angina?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 64,
    TestId = 6,
    Description = "A patient with chest pain from myocardial ischemia will MOST likely exhibit:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 65,
    TestId = 6,
    Description = "Prior to starting an exercise training program, a patient with cardiac problems who is taking beta-blocking medication should receive an explanation of the:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 66,
    TestId = 6,
    Description = "A patient with idiopathic pulmonary fibrosis completed a 6-minute walk test and demonstrates the following results: total walking distance of 1200 ft (366 m) in 6 minutes, heart rate of 82 to 110 bpm (pretest to posttest), blood pressure of 125/80 to 145/85 mm Hg (pretest to posttest), respiratory rate of 18 to 40 breaths/minute (pretest to posttest), and oxygen saturation of 98% to 92% (pretest to posttest); an electrocardiogram showed normal sinus rhythm throughout the test. Based on these results, the physical therapist should determine that the patient has impaired:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 67,
    TestId = 6,
    Description = "A 22-year-old patient is hospitalized awaiting a lung transplant due to cystic fibrosis. The patient's physician is interested in an objective measure of the patient's preoperative endurance. Which of the following tests is MOST appropriate for the physical therapist to administer to this patient?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 68,
    TestId = 6,
    Description = "A physical therapist is setting up an exercise program for a patient who is interested in improving cardiovascular fitness. When performing a submaximal cycle ergometer test the therapist should expect a relatively constant value for:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 69,
    TestId = 6,
    Description = "A patient, who has many risk factors for coronary artery disease and is presently not taking any cardiac medications, is interested in beginning an exercise program at a gym to improve cardiac health. The BEST self-assessment of exercise intensity during the exercise sessions of this patient is:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 70,
    TestId = 6,
    Description = "An important change in gastrointestinal function that occurs with aging is a(n):",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 71,
    TestId = 6,
    Description = "An important change in gastrointestinal function that occurs with aging is a(n):",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 72,
    TestId = 6,
    Description = "An active 75-year-old patient is admitted to the hospital following a fall at home. All workup is negative and comorbidities are limited to osteoarthritis, cataracts, and hypertension. Which of the following statements is the MOST accurate prognosis?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 73,
    TestId = 6,
    Description = "A 21-year-old female ballet dancer who has had an insidious onset of pelvic and hip pain is referred to physical therapy. During the history the patient reports relief of symptoms after passing gas. The patient exhibits full, pain-free hip and lumbar range of motion and normal lower extremity strength. The patient's pain is unchanged by walking or lying supine. Which of the following causes of the pain is MOST likely?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 74,
    TestId = 6,
    Description = "The medical record indicates that a patient has a deficiency of vitamin D. The patient is MOST at risk for developing which of the following conditions?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 75,
    TestId = 6,
    Description = "A patient with a chronic skin ulcer displays decreased blood pressure and skin turgor, as well as a weak, rapid pulse. A physical therapist should suspect a decreased dietary intake of:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 76,
    TestId = 6,
    Description = "Which of the following terms BEST describes a patient who has a body mass of 27 kg/m²?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},

new Question
{
    Id = 77,
    TestId = 6,
    Description = "Treatment of a patient with hemophilia who has a subacute hemarthrosis of the knee should INITIALLY include:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 78,
    TestId = 6,
    Description = "Rate pressure product is MOST indicative of which of the following cardiac factors?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
},
new Question
{
    Id = 79,
    TestId = 6,
    Description = "While walking on a treadmill during Phase II cardiac rehabilitation following coronary artery bypass surgery, a patient reports the new onset of chest pain and dyspnea. The physical therapist should instruct the patient to:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
,
new Question
{
    Id = 80,
    TestId = 6,
    Description = "A home health patient who recently had a three-vessel coronary artery bypass graft describes experiencing bilateral lower extremity swelling, leg pain, and shortness of breath, especially when lying down. The patient MOST likely has which of the following diagnoses?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}



, new Question
{
    Id = 81,
    TestId = 7,
    Description = "While walking on a treadmill during Phase II cardiac rehabilitation following coronary artery bypass surgery, a patient reports the new onset of chest pain and dyspnea. The physical therapist should instruct the patient to:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
, new Question
{
    Id = 82,
    TestId = 7,
    Description = "When providing patient education in cardiac rehabilitation, which of the following signs and symptoms of exertional intolerance should the physical therapist emphasize?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
,
new Question
{
    Id = 83,
    TestId = 7,
    Description = "Which of the following findings are associated with the LOWEST risk for a subsequent cardiac event?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
,
new Question
{
    Id = 84,
    TestId = 7,
    Description = "A patient is referred to physical therapy with thoracic spine pain. Which of the following data obtained from the patient's history is MOST likely indicative of the presence of an underlying cardiac condition?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
, new Question
{
    Id = 85,
    TestId = 7,
    Description = "A physical therapist observes a bluish discoloration of the nail beds of the toes on the operative extremity. This finding is MOST often associated with which of the following conditions?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
,
new Question
{
    Id = 86,
    TestId = 7,
    Description = "A nonathletic male patient reports occasional brief palpitations without pain, dizziness, or light-headedness. The MOST likely source of the palpitations is:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
, new Question
{
    Id = 87,
    TestId = 7,
    Description = "To manually assess a patient's lower extremity circulation, a physical therapist should palpate the patient's peripheral pulse at which of the following locations?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
,
new Question
{
    Id = 88,
    TestId = 7,
    Description = "The resting heart rate of a 32-year-old runner is measured at 46 bpm. Which of the following explanations for this heart rate is MOST likely?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
, new Question
{
    Id = 89,
    TestId = 7,
    Description = "A patient has difficulty palpating the carotid pulse during exercise. The patient should be instructed in alternate methods of self-monitoring, because repeated palpation is likely to result in:",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
, new Question
{
    Id = 90,
    TestId = 7,
    Description = "A physical therapist is walking down an isolated hospital staircase. The therapist sees a middle-aged adult lying on the landing and determines that the adult is unresponsive. What should the therapist do NEXT?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
, new Question
{
    Id = 91,
    TestId = 7,
    Description = "A patient reports a 2-week history of left upper abdominal quadrant pain, left flank pain, and mid-back pain as a result of a motor vehicle accident. The patient also reports being fatigued and generally not feeling well. Which of the following differential diagnoses would MOST likely account for the patient's symptoms?",
    CourseId = null,
    SubCategoryId = 36,
    BlogId = null
}
,
 new Question
 {
     Id = 92,
     TestId = 7,
     Description = "Clubbing of the fingers is MOST associated with which of the following conditions?",
     CourseId = null,
     SubCategoryId = 36,
     BlogId = null
 },
    new Question
    {
        Id = 93,
        TestId = 7,
        Description = "During initial examination of a patient, a physical therapist notices severe clubbing of the patient's fingernails. The therapist should further investigate for the presence of signs and symptoms associated with which of the following conditions?",
        CourseId = null,
        SubCategoryId = 36,
        BlogId = null
    },
    new Question
    {
        Id = 94,
        TestId = 7,
        Description = "A physical therapist is providing supervised exercise to a patient who has been restricted to extended bed rest. After 2 weeks of intervention, which of the following measures would BEST reflect cardiopulmonary system improvement?",
        CourseId = null,
        SubCategoryId = 36,
        BlogId = null
    },
    new Question
    {
        Id = 95,
        TestId = 7,
        Description = "A physical therapist is administering a graded exercise test. Which of the following patient responses is an ABSOLUTE indication for terminating the exercise test?",
        CourseId = null,
        SubCategoryId = 36,
        BlogId = null
    },
    new Question
    {
        Id = 96,
        TestId = 7,
        Description = "A patient who had a myocardial infarction 5 days ago is referred for a low-level treadmill test. The patient reports having had several episodes of mild angina at rest, after meals, and during the night since being hospitalized. Which of the following actions is MOST appropriate for the physical therapist?",
        CourseId = null,
        SubCategoryId = 36,
        BlogId = null
    }









            );
        }
    }
}
