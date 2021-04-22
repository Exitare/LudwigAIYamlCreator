#!/bin/bash

cd Results/
for experiment in *; do
    if [ -d "$experiment" ]; then
        # Will not run if no directories are available
        echo "Visualizing $experiment .."
        ludwig visualize --visualization learning_curves -trs ${experiment}/training_statistics.json -ff png  -od ${experiment}

        ludwig visualize --visualization learning_curves -pred ${experiment}/test_statistics.json -ff png  -od ${experiment}
        

    fi
done