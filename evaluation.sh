python3 -m venv ./venv

source ./venv/bin/activate
pip install --upgrade pip
pip install -r requirements.txt


for file in ./Results/*.yaml
do
   echo "Evaluating file $file"
   ludwig experiment \
  --dataset ludwig_data.csv \
  --config_file $file
done


