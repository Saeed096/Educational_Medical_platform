using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Educational_Medical_platform.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasData(
                // Answers for Course-related Questions
                new Answer { Id = 1, QuestionId = 1, Description = "Cell", IsCorrect = true, Reason = "Cells are the basic building blocks of life." },
                new Answer { Id = 2, QuestionId = 1, Description = "Tissue", IsCorrect = false, Reason = "Tissues are made up of cells, but they are not the smallest unit of life." },
                new Answer { Id = 3, QuestionId = 1, Description = "Organ", IsCorrect = false, Reason = "Organs are composed of tissues, which consist of cells." },

                new Answer { Id = 4, QuestionId = 2, Description = "Mitochondria", IsCorrect = true, Reason = "Mitochondria are known as the powerhouse of the cell." },
                new Answer { Id = 5, QuestionId = 2, Description = "Nucleus", IsCorrect = false, Reason = "The nucleus contains the cell's genetic material, but does not produce energy." },
                new Answer { Id = 6, QuestionId = 2, Description = "Ribosome", IsCorrect = false, Reason = "Ribosomes are responsible for protein synthesis, not energy production." },

                new Answer { Id = 7, QuestionId = 3, Description = "Protein synthesis", IsCorrect = true, Reason = "This is the primary function of ribosomes in the cell." },
                new Answer { Id = 8, QuestionId = 3, Description = "Energy production", IsCorrect = false, Reason = "Energy production occurs in the mitochondria, not during protein synthesis." },
                new Answer { Id = 9, QuestionId = 3, Description = "DNA replication", IsCorrect = false, Reason = "DNA replication is a separate process from protein synthesis." },

                new Answer { Id = 10, QuestionId = 4, Description = "Protects the cell", IsCorrect = true, Reason = "The cell membrane protects the cell from its environment." },
                new Answer { Id = 11, QuestionId = 4, Description = "Stores DNA", IsCorrect = false, Reason = "DNA is stored in the nucleus, not the cell membrane." },
                new Answer { Id = 12, QuestionId = 4, Description = "Produces energy", IsCorrect = false, Reason = "Energy production occurs in mitochondria, not the cell membrane." },

                new Answer { Id = 13, QuestionId = 5, Description = "Movement of water", IsCorrect = true, Reason = "Osmosis is the movement of water across a membrane." },
                new Answer { Id = 14, QuestionId = 5, Description = "Transport of nutrients", IsCorrect = false, Reason = "Nutrient transport occurs via active and passive transport mechanisms, not osmosis." },
                new Answer { Id = 15, QuestionId = 5, Description = "Protein synthesis", IsCorrect = false, Reason = "Protein synthesis involves ribosomes, not the movement of water." },

                // Answers for SubCategory-related Questions
                new Answer { Id = 16, QuestionId = 6, Description = "Breaks down food", IsCorrect = true, Reason = "The digestive system's primary role is to break down food." },
                new Answer { Id = 17, QuestionId = 6, Description = "Circulates blood", IsCorrect = false, Reason = "Blood circulation is the role of the circulatory system." },
                new Answer { Id = 18, QuestionId = 6, Description = "Transports oxygen", IsCorrect = false, Reason = "Oxygen transport is handled by the respiratory system." },

                new Answer { Id = 19, QuestionId = 7, Description = "Through the walls of the intestines", IsCorrect = true, Reason = "Nutrients are absorbed through the intestinal walls into the bloodstream." },
                new Answer { Id = 20, QuestionId = 7, Description = "Via the bloodstream", IsCorrect = false, Reason = "The bloodstream transports nutrients after they are absorbed." },
                new Answer { Id = 21, QuestionId = 7, Description = "By chewing", IsCorrect = false, Reason = "Chewing is part of the mechanical digestion process, not nutrient absorption." },

                new Answer { Id = 22, QuestionId = 8, Description = "Mouth, esophagus, stomach", IsCorrect = true, Reason = "These are the primary organs involved in the digestive process." },
                new Answer { Id = 23, QuestionId = 8, Description = "Brain, heart, lungs", IsCorrect = false, Reason = "These organs are not directly involved in digestion." },
                new Answer { Id = 24, QuestionId = 8, Description = "Skin, muscles, bones", IsCorrect = false, Reason = "These are not part of the digestive system." },

                new Answer { Id = 25, QuestionId = 9, Description = "They speed up chemical reactions", IsCorrect = true, Reason = "Enzymes are biological catalysts that accelerate chemical reactions." },
                new Answer { Id = 26, QuestionId = 9, Description = "They are absorbed", IsCorrect = false, Reason = "Enzymes are not absorbed; they assist in reactions." },
                new Answer { Id = 27, QuestionId = 9, Description = "They break down food", IsCorrect = false, Reason = "While enzymes help in breaking down food, they do not do so independently." },

                new Answer { Id = 28, QuestionId = 10, Description = "The wave-like motion that moves food", IsCorrect = true, Reason = "Peristalsis is the wave-like motion that moves food through the digestive tract." },
                new Answer { Id = 29, QuestionId = 10, Description = "The absorption of nutrients", IsCorrect = false, Reason = "Nutrient absorption occurs after food is moved through the digestive tract." },
                new Answer { Id = 30, QuestionId = 10, Description = "The secretion of enzymes", IsCorrect = false, Reason = "Enzyme secretion assists in digestion but is not the motion that moves food." },

                // Answers for Blog-related Questions
                new Answer { Id = 31, QuestionId = 11, Description = "Organs and systems", IsCorrect = true, Reason = "These are the correct components when discussing body structures." },
                new Answer { Id = 32, QuestionId = 11, Description = "Cells only", IsCorrect = false, Reason = "Cells are part of organs and systems, not the only component." },
                new Answer { Id = 33, QuestionId = 11, Description = "Muscles only", IsCorrect = false, Reason = "Muscles are just one type of tissue, which is part of organs and systems." },

                new Answer { Id = 34, QuestionId = 12, Description = "By contracting and relaxing", IsCorrect = true, Reason = "Muscles work by contracting and relaxing to produce movement." },
                new Answer { Id = 35, QuestionId = 12, Description = "By sending signals", IsCorrect = false, Reason = "While signaling is important, it does not describe how muscles function directly." },
                new Answer { Id = 36, QuestionId = 12, Description = "By absorbing nutrients", IsCorrect = false, Reason = "Muscles do not absorb nutrients; this is a function of the digestive system." },

                new Answer { Id = 37, QuestionId = 13, Description = "To understand the human body", IsCorrect = true, Reason = "Anatomy is studied to understand the structure and function of the body." },
                new Answer { Id = 38, QuestionId = 13, Description = "To pass exams", IsCorrect = false, Reason = "While exams may test knowledge, they are not the purpose of studying anatomy." },
                new Answer { Id = 39, QuestionId = 13, Description = "To perform surgeries", IsCorrect = false, Reason = "While anatomy knowledge is important for surgeries, it is not the sole purpose of the study." },

                new Answer { Id = 40, QuestionId = 14, Description = "Nervous, muscular, skeletal", IsCorrect = true, Reason = "These are major body systems." },
                new Answer { Id = 41, QuestionId = 14, Description = "Respiratory, circulatory", IsCorrect = false, Reason = "While important, they do not encompass all major systems." },
                new Answer { Id = 42, QuestionId = 14, Description = "Digestive, excretory", IsCorrect = false, Reason = "These systems are essential but are not all-inclusive of body systems." },

                new Answer { Id = 43, QuestionId = 15, Description = "Controls body functions", IsCorrect = true, Reason = "The nervous system regulates bodily functions." },
                new Answer { Id = 44, QuestionId = 15, Description = "Transports nutrients", IsCorrect = false, Reason = "Nutrient transport is handled by the circulatory system." },
                new Answer { Id = 45, QuestionId = 15, Description = "Provides energy", IsCorrect = false, Reason = "Energy provision is not a primary role of the nervous system." },

                // Answers for Test-related Questions
                new Answer { Id = 46, QuestionId = 16, Description = "To carry oxygen", IsCorrect = true, Reason = "Hemoglobin in red blood cells carries oxygen." },
                new Answer { Id = 47, QuestionId = 16, Description = "To fight infections", IsCorrect = false, Reason = "Fighting infections is primarily the role of the immune system." },
                new Answer { Id = 48, QuestionId = 16, Description = "To clot blood", IsCorrect = false, Reason = "Blood clotting is done by platelets and certain plasma proteins." },

                new Answer { Id = 49, QuestionId = 17, Description = "By recognizing pathogens", IsCorrect = true, Reason = "The immune system identifies and targets pathogens." },
                new Answer { Id = 50, QuestionId = 17, Description = "By producing energy", IsCorrect = false, Reason = "Energy production is not a function of the immune system." },
                new Answer { Id = 51, QuestionId = 17, Description = "By storing nutrients", IsCorrect = false, Reason = "Nutrient storage is a function of the liver and other organs." },

                new Answer { Id = 52, QuestionId = 18, Description = "Interphase, mitosis, cytokinesis", IsCorrect = true, Reason = "These are the stages of the cell cycle." },
                new Answer { Id = 53, QuestionId = 18, Description = "Prophase, metaphase, anaphase", IsCorrect = false, Reason = "These terms refer to stages of mitosis, not the entire cell cycle." },
                new Answer { Id = 54, QuestionId = 18, Description = "Meiosis only", IsCorrect = false, Reason = "Meiosis is a specific type of cell division, separate from the cell cycle." },

                new Answer { Id = 55, QuestionId = 19, Description = "Programmed cell death", IsCorrect = true, Reason = "Apoptosis is the process of programmed cell death." },
                new Answer { Id = 56, QuestionId = 19, Description = "Cell growth", IsCorrect = false, Reason = "Cell growth is a separate process from apoptosis." },
                new Answer { Id = 57, QuestionId = 19, Description = "Cell division", IsCorrect = false, Reason = "Cell division is the process of replicating cells, distinct from programmed cell death." },

                new Answer { Id = 58, QuestionId = 20, Description = "Carries genetic information", IsCorrect = true, Reason = "DNA is the molecule that carries genetic information." },
                new Answer { Id = 59, QuestionId = 20, Description = "Produces energy", IsCorrect = false, Reason = "Energy production is not a role of DNA." },
                new Answer { Id = 60, QuestionId = 20, Description = "Fights diseases", IsCorrect = false, Reason = "DNA does not directly fight diseases; it contains the instructions for making proteins." },



                // real data 
                new Answer
                {
                    Id = 61,
                    QuestionId = 21,
                    Description = "Dorsal foot, near the base of the first metatarsal",
                    IsCorrect = true,
                    Reason = ". The therapist should palpate the dorsal pedal pulse, which is found on the dorsal aspect of the foot near the base of the first metatarsal. The dorsalis pedis pulse is often used to assess a patient's circulation because of its distal location on the lower extremity. (pp. 1101-1102)"
                },
        new Answer
        {
            Id = 62,
            QuestionId = 21,
            Description = "Lateral lower leg, just posterior to the fibular head",
            IsCorrect = false,
            Reason = "The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The popliteal pulse may also be palpated, but it is located posterior to the knee, not in the lateral leg. (p. 979)"
        },
        new Answer
        {
            Id = 63,
            QuestionId = 21,
            Description = "Lateral ankle, just inferior to the lateral malleolus",
            IsCorrect = false,
            Reason = "The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The posterior tibial pulse may also be palpated, but it is located at the medial ankle just posterior to the medial malleolus, not the lateral ankle. (p. 1102)"
        },
        new Answer
        {
            Id = 64,
            QuestionId = 21,
            Description = "Plantar foot, just medial to the medial calcaneal tuberosity",
            IsCorrect = false,
            Reason = "The dorsalis pedis pulse is preferred for assessment of lower extremity circulation due to its distal location. The pulse would be palpated on the dorsal surface of the foot, not the plantar surface. The plantar foot does not possess a pulse site used in lower extremity circulation assessment. (p. 1102)"
        },

        new Answer
        {
            Id = 65,
            QuestionId = 22,
            Description = "an increase in the heart rate.",
            IsCorrect = false,
            Reason = "Heart rate is expected to decrease, not increase when the carotid sinus is overstimulated."
        },
        new Answer
        {
            Id = 66,
            QuestionId = 22,
            Description = "a decrease in the heart rate.",
            IsCorrect = true,
            Reason = "Manual pressure on the carotid sinus can cause a reflexive drop in heart rate, blood pressure, or both."
        },
        new Answer
        {
            Id = 67,
            QuestionId = 22,
            Description = "an irregular heart rhythm.",
            IsCorrect = false,
            Reason = "Heart rate, not rhythm, is expected to change due to manual pressure on the carotid sinus."
        },
        new Answer
        {
            Id = 68,
            QuestionId = 22,
            Description = "an increase in blood pressure.",
            IsCorrect = false,
            Reason = "Blood pressure is expected to decrease, not increase, due to pressure on the carotid sinus."
        },

         new Answer
         {
             Id = 69,
             QuestionId = 23,
             Description = "Initiate chest compressions.",
             IsCorrect = false,
             Reason = "When an adult is found unresponsive, the first step is to activate emergency medical services and then begin chest compressions."
         },
        new Answer
        {
            Id = 70,
            QuestionId = 23,
            Description = "Find the nearest defibrillator.",
            IsCorrect = false,
            Reason = "In the adult population, the most important factor for survival typically is time to defibrillation; therefore, it is most important to activate the emergency response system first. The proper sequence after that is to initiate chest compressions and then rescue breaths."
        },
        new Answer
        {
            Id = 71,
            QuestionId = 23,
            Description = "Initiate rescue breathing.",
            IsCorrect = false,
            Reason = "Emergency medical services should be activated first. Then chest compressions should be initiated followed by rescue breaths."
        },
        new Answer
        {
            Id = 72,
            QuestionId = 23,
            Description = "Activate the emergency response system",
            IsCorrect = true,
            Reason = "Emergency medical services should be activated first, due to the need (typically) for defibrillation in the adult."
        },

            // Seed Answers for Question 24
                new Answer
                {
                    Id = 73,
                    QuestionId = 24,
                    Description = "Chronic fatigue syndrome",
                    IsCorrect = false,
                    Reason = "The diagnostic criteria for chronic fatigue syndrome are similar to those for fibromyalgia syndrome (FMS) with the hallmark feature being fatigue (versus pain in FMS). This option does not address specifically the left upper abdominal quadrant pain, left flank pain, and mid-back pain. (p. 460)"
                },
                new Answer
                {
                    Id = 74,
                    QuestionId = 24,
                    Description = "Referred pain from the spleen",
                    IsCorrect = true,
                    Reason = "The spleen is located in the upper left abdominal quadrant. Enlargement of the spleen may be associated with the etiology and symptoms noted in the stem. (pp. 214-215)"
                },
                new Answer
                {
                    Id = 75,
                    QuestionId = 24,
                    Description = "Conversion disorder from emotional distress",
                    IsCorrect = false,
                    Reason = "A conversion disorder is defined as a condition that presents as an alteration or loss of a physical function suggestive of a physical disorder, with often an underlying psychological conflict or need. The stem does not describe a loss of function. (p. 145)"
                },
                new Answer
                {
                    Id = 76,
                    QuestionId = 24,
                    Description = "Acute onset of bladder infection",
                    IsCorrect = false,
                    Reason = "Lower abdominal pain and a strong urge to urinate are characteristics of a bladder infection. These symptoms are not described in the stem. (p. 628)"
                },
                new Answer
                {
                    Id = 77,
                    QuestionId = 25,
                    Description = "Lymphedema",
                    IsCorrect = false,
                    Reason = "Lymphedema is not commonly associated with digital clubbing. While lymphedema is associated with chronic swelling of the extremities, chronic hypoxia is not commonly observed."
                },

new Answer
{
    Id = 78,
    QuestionId = 25,
    Description = "Chronic obstructive pulmonary disease",
    IsCorrect = true,
    Reason = "Conditions that chronically interfere with tissue perfusion and nutrition may cause clubbing. Pulmonary disease is the most predominant cause of digital clubbing and is present in 75% to 85% of the cases in which clubbing is noted."
},

new Answer
{
    Id = 79,
    QuestionId = 25,
    Description = "Chronic venous insufficiency",
    IsCorrect = false,
    Reason = "Chronic venous insufficiency is not commonly associated with digital clubbing. Hemosiderin staining, lower extremity swelling, and stasis ulcers are more characteristic of venous insufficiency."
},

new Answer
{
    Id = 80,
    QuestionId = 25,
    Description = "Complex regional pain syndrome",
    IsCorrect = false,
    Reason = "Digital clubbing is not commonly associated with complex regional pain syndrome. Abnormal pain and trophic changes are characteristic of complex regional pain syndrome."
},

new Answer
{
    Id = 81,
    QuestionId = 26,
    Description = "Skin cancer",
    IsCorrect = false,
    Reason = "Nail clubbing is not associated with skin cancer."
},

new Answer
{
    Id = 82,
    QuestionId = 26,
    Description = "Renal failure",
    IsCorrect = false,
    Reason = "The nails of patients who have renal failure may appear to have short transverse lines across the nail (Mees lines) or a brownish distal one-third end of the nail (half-and-half nails), but not clubbing."
},

new Answer
{
    Id = 83,
    QuestionId = 26,
    Description = "Lung cancer",
    IsCorrect = true,
    Reason = "Severe clubbing of the nails is an abnormality associated with lung cancer and chronic hypoxia."
},

new Answer
{
    Id = 84,
    QuestionId = 26,
    Description = "Liver dysfunction",
    IsCorrect = false,
    Reason = "Liver dysfunction may result in nails with transverse depressions (Beau lines) or a nail bed that is white and extends two-thirds of the length of the nail (Terry nails)."
},
new Answer
{
    Id = 85,
    QuestionId = 27,
    Description = "Airborne",
    IsCorrect = false,
    Reason = "Methicillin-resistant Staphylococcus aureus is not spread through the air; it is spread by contact."
},

new Answer
{
    Id = 86,
    QuestionId = 27,
    Description = "Sterile",
    IsCorrect = false,
    Reason = "Sterile precautions or techniques are not necessary for the physical therapist to use with a patient infected with methicillin-resistant Staphylococcus aureus."
},

new Answer
{
    Id = 87,
    QuestionId = 27,
    Description = "Droplet",
    IsCorrect = false,
    Reason = "Methicillin-resistant Staphylococcus aureus is not spread through droplets; it is spread by contact."
},

new Answer
{
    Id = 88,
    QuestionId = 27,
    Description = "Contact",
    IsCorrect = true,
    Reason = "Methicillin-resistant Staphylococcus aureus is spread by contact."
},

new Answer
{
    Id = 89,
    QuestionId = 28,
    Description = "Jaundice",
    IsCorrect = true,
    Reason = "With a history of alcohol abuse and the presence of fine resting tremors and right upper quadrant pain, the patient is presenting a history and signs and symptoms consistent with liver disease. Jaundice is a skin change associated with disease of the hepatic system. (Goodman, p. 363)"
},

new Answer
{
    Id = 90,
    QuestionId = 28,
    Description = "Hyperhidrosis",
    IsCorrect = false,
    Reason = "Hyperhidrosis, or excessive sweating, can be present with several conditions, such as endocrine disorders, but is not associated with liver disease (Taber's, p. 1164)."
},

new Answer
{
    Id = 91,
    QuestionId = 28,
    Description = "Hypotension",
    IsCorrect = false,
    Reason = "Hypotension is not listed as a sign of liver disorders (Goodman, p. 363)."
},

new Answer
{
    Id = 92,
    QuestionId = 28,
    Description = "Nocturnal cough",
    IsCorrect = false,
    Reason = "A nocturnal cough can be associated with rheumatic fever, but is not characteristic of liver disease (Goodman, p. 260)."
},
new Answer
{
    Id = 93,
    QuestionId = 29,
    Description = "Confused mental state, muscular weakness, and presence of nausea",
    IsCorrect = false,
    Reason = "Confused mental state, weakness, and nausea are signs and symptoms of metabolic alkalosis (p. 435)."
},

new Answer
{
    Id = 94,
    QuestionId = 29,
    Description = "Large waist circumference, high triglyceride values, and high blood pressure",
    IsCorrect = true,
    Reason = "Metabolic syndrome consists of signs and symptoms that are actually risk factors and are strongly linked to type 2 diabetes, cardiovascular disease, and stroke. Metabolic syndrome is characterized by abdominal obesity (waist size > 40 in (101.6 cm), high triglycerides levels, high low-density lipids and low high-density lipids cholesterol values, and elevated blood pressure (> 130/85 mm Hg). (p. 435)"
},

new Answer
{
    Id = 95,
    QuestionId = 29,
    Description = "Headache, fatigue, and muscular twitching",
    IsCorrect = false,
    Reason = "Headache, fatigue, and muscular twitching are signs and symptoms of metabolic acidosis (p. 436)."
},

new Answer
{
    Id = 96,
    QuestionId = 29,
    Description = "Respiratory rate of 15 breaths/minute, pulse rate of 60 bpm, and body temperature of 96.5°F (35.9°C)",
    IsCorrect = false,
    Reason = "A respiratory rate of 15 breaths/min, a heart rate of 60 bpm, and body temperature of 96.5°F (35.9°C) are considered normal for older adults (pp. 161, 163, 170)."
},

new Answer
{
    Id = 97,
    QuestionId = 30,
    Description = "Abdominal thrusts",
    IsCorrect = false,
    Reason = "Abdominal thrusts or Heimlich-type assistance is primarily used in patients with low neuromuscular tone or flaccid abdominal muscles (Frownfelter, p. 343)."
},

new Answer
{
    Id = 98,
    QuestionId = 30,
    Description = "Postural drainage",
    IsCorrect = false,
    Reason = "Postural drainage facilitates drainage of secretions to the level of the segmental bronchus only. In addition, a cough is needed to clear secretions. (Hillegass, p. 541)"
},

new Answer
{
    Id = 99,
    QuestionId = 30,
    Description = "Huffing",
    IsCorrect = true,
    Reason = "Huffing helps stabilize collapsible airways present with chronic obstructive pulmonary disease (Hillegass, p. 545; Frownfelter, p. 321)."
},

new Answer
{
    Id = 100,
    QuestionId = 30,
    Description = "Manual or mechanical percussion",
    IsCorrect = false,
    Reason = "Percussion helps mobilize secretions from the periphery of the lungs; however, it does not improve the strength of the patient's cough (Hillegass, pp. 543-544)."
},

new Answer
{
    Id = 101,
    QuestionId = 31,
    Description = "Atelectasis",
    IsCorrect = true,
    Reason = "Atelectasis is more of a restrictive issue and would not lead to an increase in residual volume. Restrictive lung disease is associated with a decreased residual volume."
},

new Answer
{
    Id = 102,
    QuestionId = 31,
    Description = "Bronchiectasis",
    IsCorrect = false,
    Reason = "Bronchiectasis is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume."
},

new Answer
{
    Id = 103,
    QuestionId = 31,
    Description = "Chronic bronchitis",
    IsCorrect = false,
    Reason = "Chronic bronchitis is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume."
},

new Answer
{
    Id = 104,
    QuestionId = 31,
    Description = "Emphysema",
    IsCorrect = false,
    Reason = "Emphysema is a condition that leads to obstructive problems. Obstructive lung disease is associated with an increased residual volume."
},

new Answer
{
    Id = 105,
    QuestionId = 32,
    Description = "Vital capacity, functional residual capacity, and total lung capacity",
    IsCorrect = false,
    Reason = "Vital capacity, functional residual capacity, and total lung capacity are important measurements in the diagnosis of pulmonary disease but have minimal value for the staging of obstructive pulmonary disease (p. 196)."
},

new Answer
{
    Id = 106,
    QuestionId = 32,
    Description = "Forced inspiratory volume in 1 second and the ratio of forced inspiratory volume in 1 second to forced vital capacity",
    IsCorrect = false,
    Reason = "Forced inspiratory volume in 1 second is not a test performed during pulmonary function tests. The main issue in chronic obstructive pulmonary disease is forced expiration, and this would not be a useful measure in assessing disease progression. (pp. 196, 350)"
},

new Answer
{
    Id = 107,
    QuestionId = 32,
    Description = "Tidal volume and the ratio of tidal volume to total lung capacity",
    IsCorrect = false,
    Reason = "The tidal volume and the tidal volume/total lung capacity ratio are important in the determination of a patient's current ventilation capacity but do not factor into the staging of chronic obstructive pulmonary disease (p. 196)."
},

new Answer
{
    Id = 108,
    QuestionId = 32,
    Description = "Forced expiratory volume in 1 second and the ratio of forced expiratory volume in 1 second to forced vital capacity",
    IsCorrect = true,
    Reason = "Forced expiratory volume in 1 second and the ratio of forced expiratory volume in 1 second to forced vital capacity ratio are the most useful measurements in determining the progression of obstructive pulmonary disease and are part of the Global Initiative for Chronic Obstructive Lung Disease (GOLD) classification system (p. 196)."
},

new Answer
{
    Id = 109,
    QuestionId = 33,
    Description = "Supine exercises are best for patients with a hiatal hernia.",
    IsCorrect = false,
    Reason = "Supine position can cause the lower esophagus and stomach to be pulled into the thorax, thus increasing symptoms or discomfort. Although not contraindicated, these exercises would not be best. (p. 1429)"
},

new Answer
{
    Id = 110,
    QuestionId = 33,
    Description = "Exercise is contraindicated for patients with a hiatal hernia.",
    IsCorrect = false,
    Reason = "Exercise can help with some of the risk factors for hernia, including obesity/weight control (p. 1430)."
},

new Answer
{
    Id = 111,
    QuestionId = 33,
    Description = "There are no restrictions on exercise for patients with a hiatal hernia.",
    IsCorrect = false,
    Reason = "The physical therapist should educate the patient on the challenges of supine exercise, recumbent exercises, exercises that involve bending, and exercises that increase abdominal pressure, exacerbating symptoms (pp. 1429-1430)."
},

new Answer
{
    Id = 112,
    QuestionId = 33,
    Description = "The Valsalva maneuver should be avoided during exercise.",
    IsCorrect = true,
    Reason = "Patients who have a hiatal hernia should avoid the Valsalva maneuver. The Valsalva maneuver increases intraabdominal pressure, which can worsen the hernia (pp. 1429-1430)."
},


        new Answer
        {
            Id = 113,
            QuestionId = 34,
            Description = "Femoral",
            IsCorrect = false,
            Reason = "A hiatal hernia would most likely be associated with shoulder pain. A femoral hernia will cause pain in the lateral pelvic wall (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616)."
        },
        new Answer
        {
            Id = 114,
            QuestionId = 34,
            Description = "Hiatal",
            IsCorrect = true,
            Reason = "A hiatal hernia would most likely be associated with shoulder pain. An inguinal hernia will cause groin pain, and an umbilical hernia would most likely cause pain around the umbilical ring in the mid to lower abdomen (Goodman, Pathology, pp. 868, 898-900; Goodman, Differential Diagnosis, pp. 615-616)."
        },
        new Answer
        {
            Id = 115,
            QuestionId = 34,
            Description = "Inguinal",
            IsCorrect = false,
            Reason = "A hiatal hernia would most likely be associated with shoulder pain. An inguinal hernia will cause groin pain (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616)."
        },
        new Answer
        {
            Id = 116,
            QuestionId = 34,
            Description = "Umbilical",
            IsCorrect = false,
            Reason = "A hiatal hernia would most likely be associated with shoulder pain. An umbilical hernia would most likely cause pain around the umbilical ring in the mid to lower abdomen. (Goodman, Pathology, pp. 898-900; Goodman, Differential Diagnosis, pp. 615-616)."
        },

        new Answer
        {
            Id = 117,
            QuestionId = 35, // Reference to the Question Id
            Description = "Wall sits",
            IsCorrect = false,
            Reason = "Wall sits are performed in an upright position and would not exacerbate a hiatal hernia."
        },
new Answer
{
    Id = 118,
    QuestionId = 35,
    Description = "Overhead press",
    IsCorrect = false,
    Reason = "An overhead press is typically performed in seated, semireclined, or standing position and would not exacerbate a hiatal hernia."
},
new Answer
{
    Id = 119,
    QuestionId = 35,
    Description = "Bilateral leg lifts",
    IsCorrect = true,
    Reason = "Individuals who have a hiatal hernia should avoid supine position and avoid the Valsalva maneuver. Bilateral leg lifts must be performed in supine position and require strong contractions of the stomach muscles, encouraging the Valsalva maneuver, which would worsen the hiatal hernia."
},
new Answer
{
    Id = 120,
    QuestionId = 35,
    Description = "Hamstring stretch",
    IsCorrect = false,
    Reason = "Hamstring stretching can be modified to be done in a position other than supine to avoid exacerbating a hiatal hernia."
},

new Answer
{
    Id = 121,
    QuestionId = 36, // Reference to the Question Id
    Description = "Rheumatoid factor",
    IsCorrect = false,
    Reason = "Rheumatoid factor is appropriate for determining the presence of rheumatoid arthritis or other inflammatory conditions. A patient who has rheumatoid arthritis would be more likely to report arthralgias than myalgias. (p. 452)"
},
new Answer
{
    Id = 122,
    QuestionId = 36,
    Description = "C-reactive protein",
    IsCorrect = false,
    Reason = "The patient is describing symptoms of hypothyroidism. C-reactive protein is a nonspecific indicator of inflammation or infection. It wouldn't provide the most pertinent information with this diagnosis. (pp. 248, 465)"
},
new Answer
{
    Id = 123,
    QuestionId = 36,
    Description = "Fasting blood glucose level",
    IsCorrect = false,
    Reason = "Fasting blood glucose levels determine the amount of sugar (glucose) in the blood. This is an appropriate test for diabetes. Fatigue and weight loss are associated with diabetes; however, polyuria and polydipsia are often reported. The patient's report of myalgias and impaired thermoregulation is more consistent with hypothyroidism. (pp. 425-426)"
},
new Answer
{
    Id = 124,
    QuestionId = 36,
    Description = "Thyroid stimulating hormone level",
    IsCorrect = true,
    Reason = "The patient is describing symptoms of hypothyroidism. When hypothyroidism is present, the blood levels of thyroid hormones can be measured directly and are decreased. The main tool for the detection of thyroid disease is the measurement of thyroid stimulating hormone. (pp. 417, 420)"
},
new Answer
{
    Id = 125,
    QuestionId = 37,
    Description = "Stress",
    IsCorrect = false,
    Reason = "Stress is a secondary risk factor."
},
new Answer
{
    Id = 126,
    QuestionId = 37,
    Description = "Obesity",
    IsCorrect = false,
    Reason = "Obesity is a secondary risk factor."
},
new Answer
{
    Id = 127,
    QuestionId = 37,
    Description = "Cigarette smoking",
    IsCorrect = true,
    Reason = "High blood pressure, cigarette smoking, and hyperlipidemia are direct or primary risk factors for atherosclerosis."
},
new Answer
{
    Id = 128,
    QuestionId = 37,
    Description = "Sedentary lifestyle",
    IsCorrect = false,
    Reason = "Activity level is a secondary risk factor."
},
new Answer
{
    Id = 129,
    QuestionId = 38,
    Description = "Parathyroid",
    IsCorrect = false,
    Reason = "The parathyroid gland is responsible for calcium and phosphorus metabolism and bone calcification. It does not play a role in sexual development."
},
new Answer
{
    Id = 130,
    QuestionId = 38,
    Description = "Thyroid",
    IsCorrect = false,
    Reason = "Secretion of hormones via the thyroid gland is regulated by the pituitary gland. The thyroid secretes hormones that control metabolism and protein synthesis. It also influences calcium and phosphorus metabolism. The thyroid gland does not play a role in sexual development."
},
new Answer
{
    Id = 131,
    QuestionId = 38,
    Description = "Adrenal",
    IsCorrect = false,
    Reason = "Hormone secretion by the adrenal glands is regulated by the pituitary gland. The adrenal gland does secrete hormones responsible for secondary sexual characteristics. However, it is primarily involved in fluid/electrolyte balance and metabolism."
},
new Answer
{
    Id = 132,
    QuestionId = 38,
    Description = "Pituitary",
    IsCorrect = true,
    Reason = "The pituitary gland serves as a master gland and regulates the secretion of many hormones. The anterior pituitary glands regulate sexual development via release of gonadotropins. Gonadotropins regulate secretion of male and female hormones."
},
new Answer
{
    Id = 133,
    QuestionId = 39,
    Description = "Release of epinephrine by the adrenal gland",
    IsCorrect = true,
    Reason = "The sympathetic system is aroused during the stress response and causes the medulla of the adrenal gland to release catecholamines, such as epinephrine, norepinephrine, and dopamine, into the bloodstream. (p. 475)"
},
new Answer
{
    Id = 134,
    QuestionId = 39,
    Description = "Suppression of cortisol by the adrenal gland",
    IsCorrect = false,
    Reason = "Cortisol is a catecholamine that is increased during stress. (p. 475)"
},
new Answer
{
    Id = 135,
    QuestionId = 39,
    Description = "Release of adrenalin by the hypothalamus",
    IsCorrect = false,
    Reason = "Adrenalin is increased with stress, but it is produced by the adrenal medulla. (p. 475)"
},
new Answer
{
    Id = 136,
    QuestionId = 39,
    Description = "Suppression of growth hormone by the pituitary",
    IsCorrect = false,
    Reason = "Growth hormone may be increased as a response to stress. (p. 476)"
},
new Answer
{
    Id = 137,
    QuestionId = 40,
    Description = "Neuromuscular",
    IsCorrect = false,
    Reason = "Syndrome of inappropriate antidiuretic hormone secretion results in fluid volume excess. Fluid loss would be more likely to result in neuromuscular symptoms, such as tetany or tingling. (p. 211)"
},
new Answer
{
    Id = 138,
    QuestionId = 40,
    Description = "Integumentary",
    IsCorrect = false,
    Reason = "The skin may be warm or cool if edema is present, but there should be no concern with skin integrity in this condition (p. 211)."
},
new Answer
{
    Id = 139,
    QuestionId = 40,
    Description = "Cardiovascular",
    IsCorrect = true,
    Reason = "Syndrome of inappropriate antidiuretic hormone results in fluid volume excess, so it may cause hypertension and arrhythmias, which require monitoring as activity levels change. Also, the physical therapist may observe distended neck veins or a visible jugular pulse. (pp. 211, 482-483)"
},
new Answer
{
    Id = 140,
    QuestionId = 40,
    Description = "Musculoskeletal",
    IsCorrect = false,
    Reason = "Syndrome of inappropriate antidiuretic hormone secretion results in fluid volume excess. Fluid loss would be more likely to result in musculoskeletal symptoms, such as weakness. (p. 211)"
},
new Answer
{
    Id = 141,
    QuestionId = 41,
    Description = "Liquids are aspirated more easily than solids.",
    IsCorrect = true,
    Reason = "Dysphagia can lead to aspiration. Dysphagia can be assessed at bedside. Aspiration is more likely to occur with thin liquids. Therefore, treatment is to thicken the liquids or use thicker solutions and then progress to thinner liquids as the patient's swallowing function improves. (McCance, p. 1428)"
},
new Answer
{
    Id = 142,
    QuestionId = 41,
    Description = "Solids are aspirated more easily than liquids.",
    IsCorrect = false,
    Reason = "Aspiration is more likely to occur with thin liquids (McCance, p. 1428)."
},
new Answer
{
    Id = 143,
    QuestionId = 41,
    Description = "Cold food is easier to swallow than warm food.",
    IsCorrect = false,
    Reason = "Moist, warm food is more easily swallowed (McCance, p. 1428)."
},
new Answer
{
    Id = 144,
    QuestionId = 41,
    Description = "Hyperextension of the neck facilitates swallowing.",
    IsCorrect = false,
    Reason = "To facilitate swallowing, posture should be aligned with the chin tucked (Cifu, p. 66)."
},
new Answer
{
    Id = 145,
    QuestionId = 42,
    Description = "Heightened T wave",
    IsCorrect = false,
    Reason = ""
},
new Answer
{
    Id = 146,
    QuestionId = 42,
    Description = "Prolonged PR interval",
    IsCorrect = true,
    Reason = "Atrioventricular blocks are caused by an abnormal delay or failure of conduction through the AV node or the atrioventricular bundle. The defining characteristic of first-degree atrioventricular heart block is a prolonged PR interval. (Brannon 212)"
},
new Answer
{
    Id = 147,
    QuestionId = 42,
    Description = "Bizarre QRS complex",
    IsCorrect = false,
    Reason = ""
},
new Answer
{
    Id = 148,
    QuestionId = 42,
    Description = "Shortened ST segment",
    IsCorrect = false,
    Reason = ""
},
new Answer
{
    Id = 149,
    QuestionId = 43,
    Description = "Bradycardia",
    IsCorrect = false,
    Reason = "Bradycardia is defined as a heart rate below 60 bpm (pp. 314-315)."
},
new Answer
{
    Id = 150,
    QuestionId = 43,
    Description = "Anxiety reaction",
    IsCorrect = false,
    Reason = "Anxiety reactions typically present with an increased heart rate (pp. 315-316)."
},
new Answer
{
    Id = 151,
    QuestionId = 43,
    Description = "Acute myocardial infarction",
    IsCorrect = true,
    Reason = "Acute myocardial infarction is associated with either ST elevation or ST depression (pp. 285, 331)."
},
new Answer
{
    Id = 152,
    QuestionId = 43,
    Description = "Congestive heart failure",
    IsCorrect = false,
    Reason = "Congestive heart failure is not usually associated with ST elevation."
},
new Answer
{
    Id = 153,
    QuestionId = 44,
    Description = "arterial insufficiency.",
    IsCorrect = false,
    Reason = "With arterial insufficiency, elevation increases ischemia and, therefore, pain."
},
new Answer
{
    Id = 154,
    QuestionId = 44,
    Description = "intermittent claudication.",
    IsCorrect = false,
    Reason = "Intermittent claudication is associated with metabolic demands exceeding the capability of the vascular system to supply adequate blood flow and manifests as pain during lower extremity exercise."
},
new Answer
{
    Id = 155,
    QuestionId = 44,
    Description = "venous insufficiency.",
    IsCorrect = true,
    Reason = "With venous insufficiency, placing the limb in a dependent position increases swelling and, therefore, possibly, pain."
},
new Answer
{
    Id = 156,
    QuestionId = 44,
    Description = "a psychosomatic episode.",
    IsCorrect = false,
    Reason = "An objective sign, such as purple discoloration, rules out a psychosomatic episode."
},
new Answer
{
    Id = 157,
    QuestionId = 45,
    Description = "relief of pain with the legs elevated.",
    IsCorrect = false,
    Reason = "The patient most likely has intermittent claudication caused by arterial insufficiency. Elevating the legs in the presence of arterial insufficiency decreases blood flow, which increases pain."
},
new Answer
{
    Id = 158,
    QuestionId = 45,
    Description = "purple or brown pigmentation of the skin on the legs.",
    IsCorrect = false,
    Reason = "Purple or brown pigmentation of the skin on the legs is associated with venous insufficiency, not arterial insufficiency."
},
new Answer
{
    Id = 159,
    QuestionId = 45,
    Description = "relief of pain with the legs in the dependent position.",
    IsCorrect = true,
    Reason = "Placing the patient's legs in the dependent position facilitates blood flow and reduces pain."
},
new Answer
{
    Id = 160,
    QuestionId = 45,
    Description = "a positive Homans sign.",
    IsCorrect = false,
    Reason = "Pain with exercise is indicative of intermittent claudication, not deep vein thrombosis, which is associated with a positive Homans sign."
},
new Answer
{
    Id = 161,
    QuestionId = 46,
    Description = "signs of resting claudication",
    IsCorrect = true,
    Reason = "Peripheral vascular disease refers to a condition involving the arterial, venous, or lymphatic system that results in compromised circulation to the extremities. Resting claudication is typically considered a contraindication to active exercise in patients with peripheral vascular disease. (Kisner 631)"
},
new Answer
{
    Id = 162,
    QuestionId = 46,
    Description = "decreased peripheral pulses",
    IsCorrect = false,
    Reason = ""
},
new Answer
{
    Id = 163,
    QuestionId = 46,
    Description = "cool skin",
    IsCorrect = false,
    Reason = "" 
},
new Answer
{
    Id = 164,
    QuestionId = 46,
    Description = "blood pressure: 165/90 mm Hg",
    IsCorrect = false,
    Reason = ""
},
new Answer
{
    Id = 165,
    QuestionId = 47,
    Description = "Pressure",
    IsCorrect = false,
    Reason = "A pressure ulcer is caused by unrelieved external pressure against the skin over a bony prominence. The wound in the picture is not a pressure injury."
},
new Answer
{
    Id = 166,
    QuestionId = 47,
    Description = "Neuropathic",
    IsCorrect = true,
    Reason = "The ulcer is located on the plantar surface of the foot with decreased protective sensation, which is associated with peripheral neuropathies. Therefore, it is a neuropathic ulcer."
},
new Answer
{
    Id = 167,
    QuestionId = 47,
    Description = "Arterial insufficiency",
    IsCorrect = false,
    Reason = "Ischemic ulcers have sharply demarcated borders and are usually located over the toes or dorsum of the foot. The ulcer in question is inconsistent with arterial wounds."
},
new Answer
{
    Id = 168,
    QuestionId = 47,
    Description = "Venous insufficiency",
    IsCorrect = false,
    Reason = "Venous insufficiency ulcers are typically located proximal to the medial malleolus and do not present with decreased protective sensation."
},
new Answer
{
    Id = 170,
    QuestionId = 49,
    Description = "Edema",
    IsCorrect = false,
    Reason = "Edema would be expected for a patient who has venous insufficiency, not intermittent claudication associated with arterial insufficiency."
},
new Answer
{
    Id = 171,
    QuestionId = 49,
    Description = "Hyperhidrosis",
    IsCorrect = false,
    Reason = "Hyperhidrosis is not expected in the lower extremities of a patient experiencing intermittent claudication."
},
new Answer
{
    Id = 172,
    QuestionId = 49,
    Description = "Hyperemia",
    IsCorrect = false,
    Reason = "Pallor, not hyperemia, would be expected due to arterial insufficiency, which shunts blood away from the area."
},
new Answer
{
    Id = 173,
    QuestionId = 49,
    Description = "Pallor",
    IsCorrect = true,
    Reason = "Pallor is caused by shunting of blood to the exercising muscle and away from the distal aspect of the extremity."
},
new Answer
{
    Id = 174,
    QuestionId = 50,
    Description = "lower extremity venous stasis.",
    IsCorrect = false,
    Reason = "Venous insufficiency does not result in pale or cool skin and absent pulses."
},
new Answer
{
    Id = 175,
    QuestionId = 50,
    Description = "deep-vein thrombosis.",
    IsCorrect = false,
    Reason = "Deep vein thrombosis is generally painful but does not present with intermittent claudication symptoms."
},
new Answer
{
    Id = 176,
    QuestionId = 50,
    Description = "chronic arterial occlusion.",
    IsCorrect = true,
    Reason = "The scenario describes intermittent claudication characteristic of arterial occlusion, with pale, cool skin and absent pulses."
},
new Answer
{
    Id = 177,
    QuestionId = 50,
    Description = "weakness of the plantar flexors.",
    IsCorrect = false,
    Reason = "Weakness of the plantar flexors does not cause the pain or associated changes in skin temperature and pulse."
},

new Answer
{
    Id = 178,
    QuestionId = 51,
    Description = "Electrocardiogram",
    IsCorrect = false,
    Reason = "Beta-blockers decrease both resting and exercise heart rates, making an electrocardiogram unreliable. Although it can detect arrhythmias, it is not the best option for assessing tolerance."
},
new Answer
{
    Id = 179,
    QuestionId = 51,
    Description = "Rating of perceived exertion",
    IsCorrect = true,
    Reason = "Due to the blunted heart rate response from beta-blockers, using the rating of perceived exertion scale is recommended as it provides a better assessment of cardiovascular tolerance."
},
new Answer
{
    Id = 180,
    QuestionId = 51,
    Description = "Pulse oximetry",
    IsCorrect = false,
    Reason = "While pulse oximetry monitors oxygen saturation, the rating of perceived exertion scale is preferred over pulse oximetry for assessing cardiovascular tolerance in patients on beta-blockers."
},
new Answer
{
    Id = 181,
    QuestionId = 51,
    Description = "Heart rate",
    IsCorrect = false,
    Reason = "Beta-blockers lower both resting and exercise heart rates, making heart rate monitoring unreliable."
},

new Answer
{
    Id = 182,
    QuestionId = 52,
    Description = "loosening tight legwear and footwear before gait training.",
    IsCorrect = false,
    Reason = "Tight stockings are actually recommended to reduce orthostatic hypotension, rather than loosening legwear."
},
new Answer
{
    Id = 183,
    QuestionId = 52,
    Description = "elevating the head during a hypotensive episode.",
    IsCorrect = false,
    Reason = "The head of the bed should be lowered during a hypotensive episode to help improve blood pressure."
},
new Answer
{
    Id = 184,
    QuestionId = 52,
    Description = "instructing the patient to perform ankle pumps before standing.",
    IsCorrect = true,
    Reason = "Ankle pumps help reduce symptoms of orthostatic hypotension by promoting circulation before standing."
},
new Answer
{
    Id = 185,
    QuestionId = 52,
    Description = "encouraging the patient to consume meals prior to therapy.",
    IsCorrect = false,
    Reason = "Consuming meals before therapy does not significantly affect orthostatic hypotension."
},
new Answer
{
    Id = 186,
    QuestionId = 53,
    Description = "Decrease in diastolic blood pressure of 15 mm Hg",
    IsCorrect = true,
    Reason = "An excessive drop in blood pressure suggests the patient is not tolerating the upright position well, indicating the need to stop inclining."
},
new Answer
{
    Id = 187,
    QuestionId = 53,
    Description = "Increase in systolic blood pressure of 10 mm Hg",
    IsCorrect = false,
    Reason = "A slight increase in systolic blood pressure is normal and does not indicate intolerance to the upright position."
},
new Answer
{
    Id = 188,
    QuestionId = 53,
    Description = "Increase in heart rate of 15 bpm",
    IsCorrect = false,
    Reason = "An increase in heart rate is expected and does not signify intolerance to the upright position."
},
new Answer
{
    Id = 189,
    QuestionId = 53,
    Description = "Decrease in oxygen saturation to 93%",
    IsCorrect = false,
    Reason = "An oxygen saturation of 93% is still within the acceptable range and does not indicate intolerance to upright posture."
},
new Answer
{
    Id = 190,
    QuestionId = 54,
    Description = "Postural hypotension",
    IsCorrect = true,
    Reason = "Chronic diarrhea causes fluid loss and electrolyte imbalance, often resulting in postural hypotension."
},
new Answer
{
    Id = 191,
    QuestionId = 54,
    Description = "Hypertension",
    IsCorrect = false,
    Reason = "Due to the fluid loss from chronic diarrhea, hypertension is unlikely; hypotension is more common."
},
new Answer
{
    Id = 192,
    QuestionId = 54,
    Description = "Bradycardia",
    IsCorrect = false,
    Reason = "Typically, the heart rate increases to compensate for fluid loss, making bradycardia unlikely."
},
new Answer
{
    Id = 193,
    QuestionId = 54,
    Description = "Hypercapnia",
    IsCorrect = false,
    Reason = "Chronic diarrhea does not generally impact respiratory function, so hypercapnia is unlikely."
},
new Answer
{
    Id = 194,
    QuestionId = 55,
    Description = "Pain sensation",
    IsCorrect = false,
    Reason = "Pain sensation is not as predictive of ulceration risk as pressure threshold."
},
new Answer
{
    Id = 195,
    QuestionId = 55,
    Description = "Pressure threshold",
    IsCorrect = true,
    Reason = "Pressure thresholds using nylon filaments are highly predictive of ulceration risk. The 10-gram (Semmes-Weinstein 5.07) filament is commonly used for assessing protective sensation."
},
new Answer
{
    Id = 196,
    QuestionId = 55,
    Description = "Two-point discrimination",
    IsCorrect = false,
    Reason = "Two-point discrimination is less predictive of ulceration risk compared to pressure threshold."
},
new Answer
{
    Id = 197,
    QuestionId = 55,
    Description = "Temperature awareness",
    IsCorrect = false,
    Reason = "Temperature awareness is not as predictive of ulceration risk as pressure threshold."
},
new Answer
{
    Id = 198,
    QuestionId = 56,
    Description = "Fruity smelling breath",
    IsCorrect = false,
    Reason = "Fruity smelling breath is a sign of hyperglycemia, not hypoglycemia."
},
new Answer
{
    Id = 199,
    QuestionId = 56,
    Description = "Thirst, nausea, and vomiting",
    IsCorrect = false,
    Reason = "These are signs of hyperglycemia, not hypoglycemia."
},
new Answer
{
    Id = 200,
    QuestionId = 56,
    Description = "Dry, crusty mucous membranes",
    IsCorrect = false,
    Reason = "Dry, crusty mucous membranes are a sign of hyperglycemia."
},
new Answer
{
    Id = 201,
    QuestionId = 56,
    Description = "Difficulty speaking and concentrating",
    IsCorrect = true,
    Reason = "Mental state changes, including difficulty speaking and concentrating, are common with hypoglycemia."
},
new Answer
{
    Id = 202,
    QuestionId = 57,
    Description = "60 mg/dL (3.3 mmol/L)",
    IsCorrect = false,
    Reason = "A blood glucose level of 60 mg/dL is hypoglycemic and unsafe for exercise."
},
new Answer
{
    Id = 203,
    QuestionId = 57,
    Description = "175 mg/dL (9.7 mmol/L)",
    IsCorrect = true,
    Reason = "For safe exercise, blood glucose levels should be between 100 and 250 mg/dL."
},
new Answer
{
    Id = 204,
    QuestionId = 57,
    Description = "260 mg/dL (14.4 mmol/L)",
    IsCorrect = false,
    Reason = "260 mg/dL is hyperglycemic and unsafe for exercise."
},
new Answer
{
    Id = 205,
    QuestionId = 57,
    Description = "345 mg/dL (19.1 mmol/L)",
    IsCorrect = false,
    Reason = "345 mg/dL is hyperglycemic and unsafe for exercise."
},
new Answer
{
    Id = 206,
    QuestionId = 58,
    Description = "Type 1 diabetes mellitus",
    IsCorrect = false,
    Reason = "Type 1 diabetes cannot be prevented with exercise, though it is a beneficial intervention."
},
new Answer
{
    Id = 207,
    QuestionId = 58,
    Description = "Type 2 diabetes mellitus",
    IsCorrect = true,
    Reason = "Exercise improves glucose tolerance and reduces obesity, greatly benefiting individuals with type 2 diabetes."
},
new Answer
{
    Id = 208,
    QuestionId = 58,
    Description = "Cushing syndrome",
    IsCorrect = false,
    Reason = "While exercise may help delay symptoms, patients with Cushing syndrome often have muscle wasting and limited tolerance for exercise."
},
new Answer
{
    Id = 209,
    QuestionId = 58,
    Description = "Graves disease",
    IsCorrect = false,
    Reason = "Exercise does not prevent Graves disease, which is associated with hyperthyroidism."
},
new Answer
{
    Id = 210,
    QuestionId = 59,
    Description = "No change in glucose tolerance or risk for cardiovascular disease",
    IsCorrect = false,
    Reason = "Exercise is expected to improve glucose tolerance and reduce cardiovascular disease risk."
},
new Answer
{
    Id = 211,
    QuestionId = 59,
    Description = "No change in glucose tolerance, but a reduction in risk for cardiovascular disease",
    IsCorrect = false,
    Reason = "Improved glucose tolerance is also expected with exercise."
},
new Answer
{
    Id = 212,
    QuestionId = 59,
    Description = "Improved glucose tolerance, but no change in risk for cardiovascular disease",
    IsCorrect = false,
    Reason = "A decrease in cardiovascular disease risk is also expected."
},
new Answer
{
    Id = 213,
    QuestionId = 59,
    Description = "Improved glucose tolerance and a reduction in risk for cardiovascular disease",
    IsCorrect = true,
    Reason = "Aerobic exercise is shown to improve glucose tolerance and reduce cardiovascular risk in patients with type 2 diabetes."
},
new Answer
{
    Id = 214,
    QuestionId = 60,
    Description = "Sensory testing of the upper extremities",
    IsCorrect = false,
    Reason = "Although sensory testing is important in an initial examination, impaired sensation is less likely to occur in a patient with right-sided heart failure."
},
new Answer
{
    Id = 215,
    QuestionId = 60,
    Description = "Circumferential girth measurement of the lower extremities",
    IsCorrect = true,
    Reason = "Right-sided heart failure results in dependent edema. Circumferential girth measurements of the lower extremities are appropriate to monitor the severity of edema and aid in treatment planning."
},
new Answer
{
    Id = 216,
    QuestionId = 60,
    Description = "Resisted manual muscle testing of all extremities",
    IsCorrect = false,
    Reason = "In cases of acute right-sided heart failure, resisted manual muscle testing is generally avoided until the heart failure is more stable."
},
new Answer
{
    Id = 217,
    QuestionId = 60,
    Description = "Peripheral pulse testing of the lower extremities",
    IsCorrect = false,
    Reason = "Peripheral pulse testing is important in an initial examination, but with right-sided heart failure, edema in the lower extremities is more likely to be noted."
},
new Answer
{
    Id = 218,
    QuestionId = 61,
    Description = "History of smoking, electrocardiographic changes, and parental/family history",
    IsCorrect = false,
    Reason = "Genetic factors and family history are not modifiable factors and cannot be addressed by the physical therapist's treatment plan. Electrocardiographic changes are also not addressable by the physical therapist."
},
new Answer
{
    Id = 219,
    QuestionId = 61,
    Description = "Premorbid physical activity level, current physical condition, and motivation to exercise",
    IsCorrect = true,
    Reason = "Physical activity level, current physical condition, and motivation to exercise are modifiable factors. These factors can be addressed in the plan of care."
},
new Answer
{
    Id = 220,
    QuestionId = 61,
    Description = "Lower extremity muscle strength, waist-to-chest ratio measurement, and endurance on treadmill test",
    IsCorrect = false,
    Reason = "Lower extremity muscle strength, waist-to-chest ratio measurement, and endurance on treadmill test are not relevant to progression of coronary artery disease and do not need to be included specifically in the plan of care."
},
new Answer
{
    Id = 221,
    QuestionId = 61,
    Description = "Exercise history, daily caloric intake and dietary habits, and job responsibilities",
    IsCorrect = false,
    Reason = "Exercise history, daily caloric intake, and dietary habits are not addressable by a physical therapist's plan of care. It is more important to focus on factors within the therapist's scope, such as physical condition and motivation."
},
// For Question 62
new Answer
{
    Id = 222,
    QuestionId = 62,
    Description = "Cardiovascular",
    IsCorrect = true,
    Reason = "Midthoracic pain and upper extremity pain can be signs of angina in women. The undue weakness, fatigue, and nausea are concerning for a systemic origin of pain, particularly the cardiovascular system."
},
new Answer
{
    Id = 223,
    QuestionId = 62,
    Description = "Gastrointestinal",
    IsCorrect = false,
    Reason = "Gastrointestinal-related pain would be more likely to refer to the abdomen and pelvis."
},
new Answer
{
    Id = 224,
    QuestionId = 62,
    Description = "Musculoskeletal",
    IsCorrect = false,
    Reason = "Musculoskeletal pain is more likely to be associated with an activity that specifically engages that muscle or joint. Nausea is more indicative of a systemic source of pain."
},
new Answer
{
    Id = 225,
    QuestionId = 62,
    Description = "Neuromuscular",
    IsCorrect = false,
    Reason = "Neuromuscular pain is more likely to be described as shooting and burning, than as aching."
},

// For Question 63
new Answer
{
    Id = 226,
    QuestionId = 63,
    Description = "Episodes of nonradiating chest pain each lasting 5-15 minutes",
    IsCorrect = true,
    Reason = "Stable angina generally occurs during physical effort and is characterized by substernal, usually nonradiating pain lasting between 5 and 15 minutes."
},
new Answer
{
    Id = 227,
    QuestionId = 63,
    Description = "Episodes of severe chest pain each lasting longer than 15 minutes",
    IsCorrect = false,
    Reason = "In unstable angina, the episodes occur during physical exertion or psychological stress and are more frequent, the pain may be severe, and the duration of each event is usually greater than 15 minutes."
},
new Answer
{
    Id = 228,
    QuestionId = 63,
    Description = "Chest pain occurring at rest and unaffected by exertion",
    IsCorrect = false,
    Reason = "Variant angina occurs while the individual is at rest, usually during waking and at the same hour of the day."
},
new Answer
{
    Id = 229,
    QuestionId = 63,
    Description = "Chest pain accompanied by dysrhythmias",
    IsCorrect = false,
    Reason = "Dysrhythmias occur more commonly in individuals who have variant angina than in those with exertional angina (either stable or unstable)."
},

// For Question 64
new Answer
{
    Id = 230,
    QuestionId = 64,
    Description = "Increased pain upon chest-wall palpation.",
    IsCorrect = false,
    Reason = "Increased pain with chest-wall palpation is more indicative of a musculoskeletal origin of pain."
},
new Answer
{
    Id = 231,
    QuestionId = 64,
    Description = "Increased pain with deep breathing.",
    IsCorrect = false,
    Reason = "Increased pain with deep breathing is more indicative of a pulmonary origin of pain."
},
new Answer
{
    Id = 232,
    QuestionId = 64,
    Description = "Relief with nitroglycerin (Nitrostat).",
    IsCorrect = true,
    Reason = "Nitroglycerin (Nitrostat) is a common vasodilator that is prescribed for patients who have angina. A vasodilator will improve myocardial blood flow and help relieve ischemia and its manifestations."
},
new Answer
{
    Id = 233,
    QuestionId = 64,
    Description = "Relief with antacid.",
    IsCorrect = false,
    Reason = "Relief of pain with antacid ingestion is more indicative of referred pain from peptic ulcer disease."
},
// For Question 65
new Answer
{
    Id = 234,
    QuestionId = 65,
    Description = "Greater benefits from cardiovascular exercise to be achieved at lower rather than at higher metabolic levels.",
    IsCorrect = false,
    Reason = "Even though heart rate and blood pressure would be lower due to the beta-blocker, the patient actually achieves the same metabolic levels during exercise. The patient will not achieve greater benefits from exercise at lower metabolic levels due to taking the medication."
},
new Answer
{
    Id = 235,
    QuestionId = 65,
    Description = "Need to use measures other than heart rate to determine intensity of exercise.",
    IsCorrect = true,
    Reason = "A patient taking beta-blocking medication will experience a lower heart rate and blood pressure response during exercise, compared to a patient who is not taking this type of medication. Heart rate is lower than anticipated in patients taking beta-blockers, and using heart rate to monitor exercise intensity may not give an accurate indication of intensity. Another measure, such as the Borg scale (rating of perceived exertion), would be more beneficial."
},
new Answer
{
    Id = 236,
    QuestionId = 65,
    Description = "Need for exercise training sessions to be more frequent but of shorter duration.",
    IsCorrect = false,
    Reason = "Even though heart rate and blood pressure would be lower due to the beta-blocker, the patient actually achieves the same metabolic levels during exercise. Therefore, altering the frequency or duration of exercise is unnecessary."
},
new Answer
{
    Id = 237,
    QuestionId = 65,
    Description = "Need for longer warm-up periods and cool-down periods during exercise sessions.",
    IsCorrect = false,
    Reason = "The time for warm-up and cool-down exercises does not need to be altered."
},

// For Question 66
new Answer
{
    Id = 238,
    QuestionId = 66,
    Description = "Aerobic capacity and endurance associated with cardiovascular pump dysfunction.",
    IsCorrect = false,
    Reason = "Based on the walk test results, the heart rate and blood pressure have normal physiologic rise in response to exercise and would not indicate cardiovascular pump dysfunction."
},
new Answer
{
    Id = 239,
    QuestionId = 66,
    Description = "Ventilation, respiration, and aerobic capacity associated with airway clearance dysfunction.",
    IsCorrect = false,
    Reason = "Although the walk test results do indicate impaired ventilation and respiration, there is no indication of airway clearance issues in the question."
},
new Answer
{
    Id = 240,
    QuestionId = 66,
    Description = "Ventilation, respiration, aerobic capacity, and gas exchange associated with ventilatory pump dysfunction.",
    IsCorrect = true,
    Reason = "In general, a patient who has pulmonary fibrosis will have an impaired ventilatory pump. This is further evidenced by the exaggerated respiratory rate response and desaturation in the 6-minute walk test results."
},
new Answer
{
    Id = 241,
    QuestionId = 66,
    Description = "Aerobic capacity and endurance associated with myocardial ischemia.",
    IsCorrect = false,
    Reason = "The normal electrocardiogram does not suggest myocardial ischemia."
},

// For Question 67
new Answer
{
    Id = 242,
    QuestionId = 67,
    Description = "VO2 max treadmill test.",
    IsCorrect = false,
    Reason = "The VO2 max treadmill test examines functional cardiovascular capacity, not necessarily endurance."
},
new Answer
{
    Id = 243,
    QuestionId = 67,
    Description = "Two-step exercise test.",
    IsCorrect = false,
    Reason = "The two-step exercise test is the clinical standard for assessing exercise-induced ischemia. This test can reach VO2 max, which is not appropriate for the patient described."
},
new Answer
{
    Id = 244,
    QuestionId = 67,
    Description = "Submaximal exercise test on a cycle ergometer.",
    IsCorrect = false,
    Reason = "The submaximal exercise test is used to estimate VO2 max and assesses aerobic power, not endurance."
},
new Answer
{
    Id = 245,
    QuestionId = 67,
    Description = "6-minute walk test.",
    IsCorrect = true,
    Reason = "The 6-minute walk test is designed to measure endurance for acutely ill individuals with cardiovascular and pulmonary dysfunction."
},

// For Question 68
new Answer
{
    Id = 246,
    QuestionId = 68,
    Description = "Oxygen consumption.",
    IsCorrect = false,
    Reason = "An increase in oxygen uptake occurs in response to increased workload."
},
new Answer
{
    Id = 247,
    QuestionId = 68,
    Description = "Heart rate.",
    IsCorrect = false,
    Reason = "Heart rate increases gradually in response to increased workload."
},
new Answer
{
    Id = 248,
    QuestionId = 68,
    Description = "Systolic blood pressure.",
    IsCorrect = false,
    Reason = "Systolic blood pressure should increase with increasing workload by approximately 10 mm Hg per 1 metabolic equivalent (MET) increase."
},
new Answer
{
    Id = 249,
    QuestionId = 68,
    Description = "Diastolic blood pressure.",
    IsCorrect = true,
    Reason = "Diastolic blood pressure should remain relatively constant during exercise, remaining within 10 mm Hg of the starting point."
},

// For Question 69
new Answer
{
    Id = 250,
    QuestionId = 69,
    Description = "Change in systolic blood pressure.",
    IsCorrect = false,
    Reason = "Systolic blood pressure is a useful measure of exercise intensity, but it is not easily assessed by the patient."
},
new Answer
{
    Id = 251,
    QuestionId = 69,
    Description = "MET (metabolic equivalent) level.",
    IsCorrect = false,
    Reason = "A MET is a metabolic equivalent of an individual's resting metabolic rate. It varies based on individual factors and is generally too complex for patient self-assessment."
},
new Answer
{
    Id = 252,
    QuestionId = 69,
    Description = "Rating of perceived exertion.",
    IsCorrect = true,
    Reason = "The rating of perceived exertion scale is subjective and fairly accurate for assessing ventilatory threshold."
},
new Answer
{
    Id = 253,
    QuestionId = 69,
    Description = "Respiratory rate.",
    IsCorrect = false,
    Reason = "Respiratory rate is a useful measure of exercise intensity, but it is not easily assessed by the patient."
},
new Answer
{
    Id = 254,
    QuestionId = 70,
    Description = "increase in gastric motility",
    IsCorrect = false,
    Reason = "Gastric motility decreases with aging."
},
new Answer
{
    Id = 255,
    QuestionId = 70,
    Description = "increase in salivary secretion",
    IsCorrect = false,
    Reason = "Salivary secretion decreases with aging."
},
new Answer
{
    Id = 256,
    QuestionId = 70,
    Description = "decrease in tooth decay",
    IsCorrect = false,
    Reason = "Tooth decay increases due to enamel and dentin wear and decreased saliva."
},
new Answer
{
    Id = 257,
    QuestionId = 70,
    Description = "decrease in nutrient absorption",
    IsCorrect = true,
    Reason = "Aging includes a decrease in nutrient absorption."
},

new Answer
{
    Id = 258,
    QuestionId = 71,
    Description = "increase in gastric motility",
    IsCorrect = false,
    Reason = "Gastric motility decreases with aging."
},
new Answer
{
    Id = 259,
    QuestionId = 71,
    Description = "increase in salivary secretion",
    IsCorrect = false,
    Reason = "Salivary secretion decreases with aging."
},
new Answer
{
    Id = 260,
    QuestionId = 71,
    Description = "decrease in tooth decay",
    IsCorrect = false,
    Reason = "Tooth decay increases due to enamel and dentin wear and decreased saliva."
},
new Answer
{
    Id = 261,
    QuestionId = 71,
    Description = "decrease in nutrient absorption",
    IsCorrect = true,
    Reason = "Aging includes a decrease in nutrient absorption."
},

new Answer
{
    Id = 262,
    QuestionId = 72,
    Description = "Patient should return to the previous level of function within 1 week.",
    IsCorrect = true,
    Reason = "A prognosis is the predicted optimal level of improvement in function reached in a certain time period. The patient's comorbidities are common in older adults, and with gait and balance training, the patient is expected to return to normal activities."
},
new Answer
{
    Id = 263,
    QuestionId = 72,
    Description = "Patient will be independent with a walker on all surfaces in 3 weeks.",
    IsCorrect = false,
    Reason = "There is no mention of gait dysfunction in the question; assuming the patient needs a walker is inappropriate."
},
new Answer
{
    Id = 264,
    QuestionId = 72,
    Description = "Patient will need to use a wheelchair at home to avoid falls.",
    IsCorrect = false,
    Reason = "The patient should be given an opportunity to ambulate safely before being considered for a wheelchair."
},
new Answer
{
    Id = 265,
    QuestionId = 72,
    Description = "Patient should be transferred to a skilled nursing facility for safety.",
    IsCorrect = false,
    Reason = "The patient's workup is negative, and with gait and balance retraining, the patient should be able to resume normal activity at home."
},

new Answer
{
    Id = 266,
    QuestionId = 73,
    Description = "Pancreatitis",
    IsCorrect = false,
    Reason = "Pancreatitis will typically be made worse by walking or lying in supine position."
},
new Answer
{
    Id = 267,
    QuestionId = 73,
    Description = "Lumbar herniated nucleus pulposus",
    IsCorrect = false,
    Reason = "A herniated nucleus pulposus typically causes loss of lumbar motion, and the symptoms are relieved with lying supine."
},
new Answer
{
    Id = 268,
    QuestionId = 73,
    Description = "Sacroiliac dysfunction",
    IsCorrect = false,
    Reason = "Sacroiliac dysfunction typically causes decreased hip or lumbar range of motion and is not affected by passing gas."
},
new Answer
{
    Id = 269,
    QuestionId = 73,
    Description = "Crohn disease",
    IsCorrect = true,
    Reason = "Crohn disease can refer pain to the pelvic area and hip that is relieved by passing gas."
},

new Answer
{
    Id = 270,
    QuestionId = 74,
    Description = "Fragile skin",
    IsCorrect = false,
    Reason = "Vitamin D is not primarily involved in maintaining skin integrity."
},
new Answer
{
    Id = 271,
    QuestionId = 74,
    Description = "Excessive bleeding",
    IsCorrect = false,
    Reason = "Bleeding disorders are related to hematological disorders, not vitamin D deficiency."
},
new Answer
{
    Id = 272,
    QuestionId = 74,
    Description = "Bone decalcification",
    IsCorrect = true,
    Reason = "Vitamin D is important for calcium absorption, synthesis, and transport, and bone decalcification can result from a deficiency."
},
new Answer
{
    Id = 273,
    QuestionId = 74,
    Description = "Poor vision",
    IsCorrect = false,
    Reason = "Vitamin D is not primarily involved in maintaining proper vision."
},

new Answer
{
    Id = 274,
    QuestionId = 75,
    Description = "Protein",
    IsCorrect = false,
    Reason = "Too much protein may lead to greater water needs; too little will prevent the development of a wound bed. Protein level does not have a direct effect on heart rate or blood pressure."
},
new Answer
{
    Id = 275,
    QuestionId = 75,
    Description = "Water",
    IsCorrect = true,
    Reason = "Water aids in hydration of the wound site, and dehydration will result in elevated heart rate and decreased blood pressure."
},
new Answer
{
    Id = 276,
    QuestionId = 75,
    Description = "Vitamin B",
    IsCorrect = false,
    Reason = "Vitamin B is critical in the rebuilding/remodeling stage, but it does not affect heart rate or blood pressure."
},
new Answer
{
    Id = 277,
    QuestionId = 75,
    Description = "Carbohydrates",
    IsCorrect = false,
    Reason = "Carbohydrates are important for overall energy needs but do not directly affect heart rate or blood pressure."
},
new Answer
{
    Id = 278,
    QuestionId = 76,
    Description = "Normal weight",
    IsCorrect = false,
    Reason = "Body mass index (BMI) for normal weight is 18.5-24.9."
},
new Answer
{
    Id = 279,
    QuestionId = 76,
    Description = "Underweight",
    IsCorrect = false,
    Reason = "BMI for underweight is less than 18.5."
},
new Answer
{
    Id = 280,
    QuestionId = 76,
    Description = "Overweight",
    IsCorrect = true,
    Reason = "The correct answer according to the BMI rating scale is overweight, which is indicated by a BMI of 25-29.9."
},
new Answer
{
    Id = 281,
    QuestionId = 76,
    Description = "Obese",
    IsCorrect = false,
    Reason = "BMI for obese is more than 30."
},
new Answer
{
    Id = 282,
    QuestionId = 77,
    Description = "active assistive range-of-motion exercise to the knee",
    IsCorrect = true,
    Reason = "In this stage of hemarthrosis, there is still some bleeding into the joint space, but it is not as extensive as during the acute phase. Therefore, the patient will benefit from range-of-motion exercise to prevent contracture. The patient may need active-assistive exercises, because there may still be pain or edema in the joint that prevents independent performance of range of motion."
},
new Answer
{
    Id = 283,
    QuestionId = 77,
    Description = "instruction of the patient for weight-bearing to tolerance",
    IsCorrect = false,
    Reason = "The mechanical trauma of weight-bearing to tolerance at this stage may impinge on and damage the pathologic synovium within the joint."
},
new Answer
{
    Id = 284,
    QuestionId = 77,
    Description = "gentle resistive range-of-motion exercise to the knee",
    IsCorrect = false,
    Reason = "Resistive range of motion is more appropriate when pain and swelling have subsided and bleeding is not occurring."
},
new Answer
{
    Id = 285,
    QuestionId = 77,
    Description = "continuous immobilization of the knee in an extension splint",
    IsCorrect = false,
    Reason = "Continuous immobilization in the extended position will promote contracture in the edematous knee."
},

new Answer
{
    Id = 286,
    QuestionId = 78,
    Description = "Stroke volume",
    IsCorrect = false,
    Reason = "Stroke volume is the amount of blood ejected from the left ventricle during each heartbeat and is not directly related to rate pressure product."
},
new Answer
{
    Id = 287,
    QuestionId = 78,
    Description = "Cardiac output",
    IsCorrect = false,
    Reason = "Cardiac output is calculated by multiplying stroke volume by heart rate, but rate pressure product specifically relates to myocardial oxygen demand."
},
new Answer
{
    Id = 288,
    QuestionId = 78,
    Description = "Pulse amplitude",
    IsCorrect = false,
    Reason = "Pulse amplitude refers to the quality of the pulse and is unrelated to rate pressure product."
},
new Answer
{
    Id = 289,
    QuestionId = 78,
    Description = "Myocardial oxygen demand",
    IsCorrect = true,
    Reason = "Rate pressure product is calculated by multiplying heart rate by systolic blood pressure and is an indication of myocardial oxygen demand."
},

new Answer
{
    Id = 290,
    QuestionId = 79,
    Description = "continue walking while the therapist monitors the patient's vital signs",
    IsCorrect = false,
    Reason = "Continuing to walk is inappropriate. Angina during exercise should result in termination of the activity."
},
new Answer
{
    Id = 291,
    QuestionId = 79,
    Description = "continue walking at 50% slower speed while the therapist calls the physician",
    IsCorrect = false,
    Reason = "These are indications to terminate exercise and reassess vital signs. Continuing to walk at a lower intensity is inappropriate."
},
new Answer
{
    Id = 292,
    QuestionId = 79,
    Description = "cease walking while the therapist reassesses the patient's vital signs",
    IsCorrect = true,
    Reason = "An episode of stable angina is an indication to terminate exercise testing and reassess vital signs."
},
new Answer
{
    Id = 293,
    QuestionId = 79,
    Description = "cease walking while the therapist activates the emergency medical system",
    IsCorrect = false,
    Reason = "These symptoms do not constitute a medical emergency. It is more appropriate to reassess vitals and ask the patient to take nitroglycerin, if prescribed."
}, new Answer
{
    Id = 294,
    QuestionId = 80,
    Description = "Deep vein thrombosis",
    IsCorrect = false,
    Reason = "A deep vein thrombosis typically causes unilateral leg swelling and pain, not bilateral."
},
new Answer
{
    Id = 295,
    QuestionId = 80,
    Description = "Myocardial infarction",
    IsCorrect = false,
    Reason = "While myocardial infarction may cause shortness of breath, it does not typically cause bilateral swelling. Heart failure could result from a myocardial infarction."
},
new Answer
{
    Id = 296,
    QuestionId = 80,
    Description = "Pulmonary embolism",
    IsCorrect = false,
    Reason = "A pulmonary embolism causes shortness of breath but is not typically associated with bilateral lower extremity swelling or pain."
},
new Answer
{
    Id = 297,
    QuestionId = 80,
    Description = "Heart failure",
    IsCorrect = true,
    Reason = "Heart failure is characterized by symptoms like dyspnea, orthopnea, paroxysmal nocturnal dyspnea, and peripheral edema, all of which are present in this patient."
}
, new Answer
{
    Id = 298,
    QuestionId = 81,
    Description = "continue walking while the therapist monitors the patient's vital signs",
    IsCorrect = false,
    Reason = "Continuing to walk is inappropriate. Angina during exercise should result in termination of the activity."
},
new Answer
{
    Id = 299,
    QuestionId = 81,
    Description = "continue walking at 50% slower speed while the therapist calls the physician",
    IsCorrect = false,
    Reason = "These are indications to terminate exercise and reassess vital signs. Continuing to walk at a lower intensity is inappropriate."
},
new Answer
{
    Id = 300,
    QuestionId = 81,
    Description = "cease walking while the therapist reassesses the patient's vital signs",
    IsCorrect = true,
    Reason = "An episode of stable angina is an indication to terminate exercise testing and reassess vital signs."
},
new Answer
{
    Id = 301,
    QuestionId = 81,
    Description = "cease walking while the therapist activates the emergency medical system",
    IsCorrect = false,
    Reason = "These symptoms do not constitute a medical emergency. It is more appropriate to reassess vitals and ask the patient to take nitroglycerin, if prescribed."
}
,
new Answer
{
    Id = 302,
    QuestionId = 82,
    Description = "Anginal pain, insomnia, sudden weight gain, leg stiffness",
    IsCorrect = false,
    Reason = "Leg stiffness is not typically associated with exertional intolerance among patients undergoing cardiac rehabilitation."
},
new Answer
{
    Id = 303,
    QuestionId = 82,
    Description = "Persistent dyspnea, dizziness, anginal pain, sudden weight gain",
    IsCorrect = true,
    Reason = "These are classic signs of exertional intolerance that should be emphasized during cardiac rehabilitation."
},
new Answer
{
    Id = 304,
    QuestionId = 82,
    Description = "Persistent dyspnea, anginal pain, insomnia, weight loss",
    IsCorrect = false,
    Reason = "Weight loss is not a typical symptom of exertional intolerance. Angina and dyspnea are more critical signs."
},
new Answer
{
    Id = 305,
    QuestionId = 82,
    Description = "Anginal pain, confusion, leg numbness, weight loss",
    IsCorrect = false,
    Reason = "Leg numbness, confusion, and weight loss are not signs associated with exertional intolerance."
}

, new Answer
{
    Id = 306,
    QuestionId = 83,
    Description = "Left ventricular ejection fraction of 55% and functional capacity of 3 metabolic equivalents (METs)",
    IsCorrect = false,
    Reason = "A functional capacity below 5-6 METs places a patient at moderate risk for morbidity and mortality."
},
new Answer
{
    Id = 307,
    QuestionId = 83,
    Description = "Occasional premature ventricular contractions and functional capacity of 6 metabolic equivalents (METs)",
    IsCorrect = true,
    Reason = "A functional capacity of 6 METs or greater and occasional PVCs are associated with low risk for morbidity and mortality."
},
new Answer
{
    Id = 308,
    QuestionId = 83,
    Description = "Exercise-induced ST segment depression of less than 2 mm and sustained supraventricular tachycardia",
    IsCorrect = false,
    Reason = "ST segment depression and SVT indicate ischemia and an arrhythmia, suggesting higher risk for cardiac events."
},
new Answer
{
    Id = 309,
    QuestionId = 83,
    Description = "Exercise-induced ST segment depression of greater than 2 mm and left ventricular ejection fraction of 45%",
    IsCorrect = false,
    Reason = "An ejection fraction below 55% and ST depression >2mm indicate high risk for future cardiac events."
}
, new Answer
{
    Id = 310,
    QuestionId = 84,
    Description = "Sharp mid back pain that increases with lifting of heavy objects",
    IsCorrect = false,
    Reason = "This type of pain is typically related to musculoskeletal or nerve issues, not cardiac."
},
new Answer
{
    Id = 311,
    QuestionId = 84,
    Description = "Increased pain with deep breathing",
    IsCorrect = false,
    Reason = "Pain with breathing is often associated with pulmonary or rib movement, not cardiac."
},
new Answer
{
    Id = 312,
    QuestionId = 84,
    Description = "Feeling of heaviness in the chest",
    IsCorrect = true,
    Reason = "Heaviness in the chest may indicate a cardiovascular issue, warranting physician referral."
},
new Answer
{
    Id = 313,
    QuestionId = 84,
    Description = "Persistent night pain",
    IsCorrect = false,
    Reason = "Night pain often suggests a musculoskeletal issue or potentially cancer, not primarily cardiac."
}
, new Answer
{
    Id = 314,
    QuestionId = 85,
    Description = "Decreased peripheral blood flow",
    IsCorrect = true,
    Reason = "Peripheral cyanosis is typically linked to decreased peripheral blood flow."
},
new Answer
{
    Id = 315,
    QuestionId = 85,
    Description = "Deep vein thrombosis",
    IsCorrect = false,
    Reason = "DVT is usually accompanied by swelling and tenderness, not cyanosis alone."
},
new Answer
{
    Id = 316,
    QuestionId = 85,
    Description = "Lymphedema",
    IsCorrect = false,
    Reason = "Lymphedema typically results in swelling rather than cyanosis."
},
new Answer
{
    Id = 317,
    QuestionId = 85,
    Description = "Aneurysm",
    IsCorrect = false,
    Reason = "An aneurysm often presents as a pulsing mass, not peripheral cyanosis."
}
, new Answer
{
    Id = 318,
    QuestionId = 86,
    Description = "Gender",
    IsCorrect = false,
    Reason = "Gender-related hormonal changes are unlikely in a healthy male without cardiovascular symptoms."
},
new Answer
{
    Id = 319,
    QuestionId = 86,
    Description = "Sedentary activity level",
    IsCorrect = false,
    Reason = "Sedentary lifestyle is not a primary cause of palpitations without other symptoms."
},
new Answer
{
    Id = 320,
    QuestionId = 86,
    Description = "Excess caffeine intake",
    IsCorrect = true,
    Reason = "Excessive caffeine is a common, non-cardiac cause of palpitations in healthy individuals."
},
new Answer
{
    Id = 321,
    QuestionId = 86,
    Description = "Cardiac abnormality",
    IsCorrect = false,
    Reason = "Cardiac-origin palpitations usually come with symptoms like dyspnea or light-headedness."
}
, new Answer
{
    Id = 322,
    QuestionId = 87,
    Description = "Dorsal foot, near the base of the first metatarsal",
    IsCorrect = true,
    Reason = "The dorsal pedal pulse, found near the base of the first metatarsal, is commonly used to assess circulation due to its distal location."
},
new Answer
{
    Id = 323,
    QuestionId = 87,
    Description = "Lateral lower leg, just posterior to the fibular head",
    IsCorrect = false,
    Reason = "The popliteal pulse, not located in the lateral lower leg, is an alternative but less distal location."
},
new Answer
{
    Id = 324,
    QuestionId = 87,
    Description = "Lateral ankle, just inferior to the lateral malleolus",
    IsCorrect = false,
    Reason = "The posterior tibial pulse is located at the medial, not lateral, ankle."
},
new Answer
{
    Id = 325,
    QuestionId = 87,
    Description = "Plantar foot, just medial to the medial calcaneal tuberosity",
    IsCorrect = false,
    Reason = "The plantar surface does not have a pulse point typically used for assessing circulation in the lower extremity."
}
, new Answer
{
    Id = 326,
    QuestionId = 88,
    Description = "The individual has a hypotensive disorder.",
    IsCorrect = false,
    Reason = "Bradycardia in this case is more likely due to a training effect rather than hypotension."
},
new Answer
{
    Id = 327,
    QuestionId = 88,
    Description = "The rate is secondary to an increased stroke volume.",
    IsCorrect = true,
    Reason = "Endurance training increases stroke volume, leading to a compensatory decrease in resting heart rate to maintain cardiac output."
},
new Answer
{
    Id = 328,
    QuestionId = 88,
    Description = "The individual has an atrioventricular block.",
    IsCorrect = false,
    Reason = "The low heart rate is more consistent with a training effect, not a conduction block."
},
new Answer
{
    Id = 329,
    QuestionId = 88,
    Description = "Endurance training has stimulated the sympathetic nervous system.",
    IsCorrect = false,
    Reason = "Endurance training actually increases parasympathetic activity and reduces sympathetic discharge, lowering the resting heart rate."
}
, new Answer
{
    Id = 330,
    QuestionId = 89,
    Description = "an increase in the heart rate.",
    IsCorrect = false,
    Reason = "Overstimulation of the carotid sinus decreases heart rate, not increases it."
},
new Answer
{
    Id = 331,
    QuestionId = 89,
    Description = "a decrease in the heart rate.",
    IsCorrect = true,
    Reason = "Manual pressure on the carotid sinus can trigger a reflexive drop in heart rate and blood pressure."
},
new Answer
{
    Id = 332,
    QuestionId = 89,
    Description = "an irregular heart rhythm.",
    IsCorrect = false,
    Reason = "The heart rate, not the rhythm, changes due to carotid sinus pressure."
},
new Answer
{
    Id = 333,
    QuestionId = 89,
    Description = "an increase in blood pressure.",
    IsCorrect = false,
    Reason = "Carotid sinus stimulation decreases, not increases, blood pressure."
}
, new Answer
{
    Id = 334,
    QuestionId = 90,
    Description = "Initiate chest compressions.",
    IsCorrect = false,
    Reason = "While chest compressions are important, the first action is to activate the emergency response system before beginning compressions."
},
new Answer
{
    Id = 335,
    QuestionId = 90,
    Description = "Find the nearest defibrillator.",
    IsCorrect = false,
    Reason = "Time to defibrillation is critical, but activating the emergency response system is the first priority to ensure help is on the way."
},
new Answer
{
    Id = 336,
    QuestionId = 90,
    Description = "Initiate rescue breathing.",
    IsCorrect = false,
    Reason = "Rescue breathing is part of the CPR process, but activating the emergency response system is the necessary first step."
},
new Answer
{
    Id = 337,
    QuestionId = 90,
    Description = "Activate the emergency response system",
    IsCorrect = true,
    Reason = "The first action is to activate emergency medical services to ensure timely defibrillation and additional support, then proceed with CPR as needed."
},
new Answer
{
    Id = 338,
    QuestionId = 91,
    Description = "Chronic fatigue syndrome",
    IsCorrect = false,
    Reason = "Chronic fatigue syndrome is mainly characterized by fatigue rather than pain localized to the left upper quadrant, flank, and mid-back, which points to a different etiology."
},
new Answer
{
    Id = 339,
    QuestionId = 91,
    Description = "Referred pain from the spleen",
    IsCorrect = true,
    Reason = "The spleen is located in the left upper abdominal quadrant, and its enlargement or trauma could cause referred pain in this region and explain the patient's symptoms."
},
new Answer
{
    Id = 340,
    QuestionId = 91,
    Description = "Conversion disorder from emotional distress",
    IsCorrect = false,
    Reason = "Conversion disorder involves loss of function often linked to psychological conflict; however, this case does not involve any described functional loss."
},
new Answer
{
    Id = 341,
    QuestionId = 91,
    Description = "Acute onset of bladder infection",
    IsCorrect = false,
    Reason = "Bladder infections typically present with lower abdominal pain and urinary symptoms, not pain localized to the left upper quadrant, flank, and mid-back."
}
,
   new Answer
    {
        Id = 342,
        QuestionId = 92,
        Description = "Lymphedema",
        IsCorrect = false,
        Reason = "Lymphedema is associated with swelling but not typically with digital clubbing, which is more common in chronic hypoxic conditions."
    },
    new Answer
    {
        Id = 343,
        QuestionId = 92,
        Description = "Chronic obstructive pulmonary disease",
        IsCorrect = true,
        Reason = "Pulmonary diseases that affect oxygenation can cause digital clubbing; COPD is a predominant cause."
    },
    new Answer
    {
        Id = 344,
        QuestionId = 92,
        Description = "Chronic venous insufficiency",
        IsCorrect = false,
        Reason = "Chronic venous insufficiency is more often associated with leg swelling and stasis ulcers rather than digital clubbing."
    },
    new Answer
    {
        Id = 345,
        QuestionId = 92,
        Description = "Complex regional pain syndrome",
        IsCorrect = false,
        Reason = "CRPS is characterized by pain and trophic changes but does not typically include clubbing of the fingers."
    },
    new Answer
    {
        Id = 346,
        QuestionId = 93,
        Description = "Skin cancer",
        IsCorrect = false,
        Reason = "Skin cancer is not associated with nail clubbing."
    },
    new Answer
    {
        Id = 347,
        QuestionId = 93,
        Description = "Renal failure",
        IsCorrect = false,
        Reason = "Renal failure may cause specific nail changes but not clubbing, which is more indicative of pulmonary issues like lung cancer."
    },
    new Answer
    {
        Id = 348,
        QuestionId = 93,
        Description = "Lung cancer",
        IsCorrect = true,
        Reason = "Lung cancer and other conditions causing chronic hypoxia are strongly associated with severe clubbing of the nails."
    },
    new Answer
    {
        Id = 349,
        QuestionId = 93,
        Description = "Liver dysfunction",
        IsCorrect = false,
        Reason = "Liver dysfunction can cause specific nail changes (e.g., Beau lines, Terry nails) but is not associated with clubbing."
    },
    new Answer
    {
        Id = 350,
        QuestionId = 94,
        Description = "Delayed cardiovascular response upon rising from supine position",
        IsCorrect = false,
        Reason = "Early mobilization improves venous return and adaptation to positional changes, which should enhance rather than delay cardiovascular response."
    },
    new Answer
    {
        Id = 351,
        QuestionId = 94,
        Description = "Decreased heart rate response to exercise",
        IsCorrect = true,
        Reason = "With conditioning, the heart rate response to exercise is reduced as stroke volume and myocardial contractility increase."
    },
    new Answer
    {
        Id = 352,
        QuestionId = 94,
        Description = "Decreased respiratory rate in response to exercise",
        IsCorrect = false,
        Reason = "Early mobilization will improve respiratory function, but a reduction in heart rate response is more specific to cardiopulmonary conditioning."
    },
    new Answer
    {
        Id = 353,
        QuestionId = 94,
        Description = "Increased cardiovascular peripheral resistance",
        IsCorrect = false,
        Reason = "Cardiovascular resistance tends to decrease with training, improving blood vessel responsiveness and vascular reflexes."
    },
    new Answer
    {
        Id = 354,
        QuestionId = 95,
        Description = "Fatigue, shortness of breath, or wheezing",
        IsCorrect = false,
        Reason = "These are relative indications to stop a test, but they are not absolute contraindications."
    },
    new Answer
    {
        Id = 355,
        QuestionId = 95,
        Description = "A drop in systolic blood pressure of 10 mm Hg in the absence of ischemic changes",
        IsCorrect = false,
        Reason = "A drop in systolic blood pressure without ischemia is a relative indication, not an absolute indication, to stop the test."
    },
    new Answer
    {
        Id = 356,
        QuestionId = 95,
        Description = "A request to stop the test",
        IsCorrect = true,
        Reason = "The test should be immediately terminated if the patient requests it to be stopped."
    },
    new Answer
    {
        Id = 357,
        QuestionId = 95,
        Description = "A rise in diastolic blood pressure to 90 mm Hg",
        IsCorrect = false,
        Reason = "While elevated blood pressure is a concern, a rise to 90 mm Hg is not an absolute indication to stop the test."
    },
    new Answer
    {
        Id = 358,
        QuestionId = 96,
        Description = "Proceed with the usual low-level protocol, because mild angina is common this soon after a myocardial infarction.",
        IsCorrect = false,
        Reason = "Unstable angina warrants immediate medical attention rather than proceeding with exercise testing."
    },
    new Answer
    {
        Id = 359,
        QuestionId = 96,
        Description = "Defer testing the patient, because the symptoms suggest unstable angina after a myocardial infarction.",
        IsCorrect = true,
        Reason = "Unstable angina following a myocardial infarction requires immediate medical attention and testing should be deferred."
    },
    new Answer
    {
        Id = 360,
        QuestionId = 96,
        Description = "Perform the test at a lower-than-usual workload, because the symptoms suggest unstable angina after a myocardial infarction.",
        IsCorrect = false,
        Reason = "Any exercise with unstable angina is contraindicated and the patient should be evaluated immediately."
    },
    new Answer
    {
        Id = 361,
        QuestionId = 96,
        Description = "Defer testing the patient, because 5 days after a myocardial infarction is too soon to begin physical exertion.",
        IsCorrect = false,
        Reason = "Exercise testing is typically done before discharge after a myocardial infarction, provided there are no unstable symptoms."
    }















                    );
        }
    }
}
