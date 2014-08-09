#import-module humanize;

Describing "format-forHuman" {
    Given "mouse" {
   
        $i = "mouse";
   

        It "Pluralizes" {
            $i | format-forHuman -plural | should be "mice"                    
        }

        It "Singularizes" {
            $i | format-forHuman -singular | should be "mouse"                    
        }

        It "SentenceCases" {
            $i | format-forHuman -sentence | should be "Mouse"                    
        }

        It "LowerCases" {
            $i | format-forHuman -lower | should be "mouse"                    
        }

        It "UpperCases" {
            $i | format-forHuman -upper | should be "MOUSE"                    
        }
    }

    Given "a 10:12 minute timespan" {
   
        $i = new-timespan -minutes 10 -seconds 12;
   
        It "Humanizes" {
            $i | format-forHuman | should be "10 minutes"                    
        }
    }
}

