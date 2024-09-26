from flask import Flask, render_template
import requests

app = Flask(__name__)

@app.route('/')
def home():
    response = requests.get("http://dotnet:8080/cats")
    
    print(response)
    if response.status_code == 200:
        cats_data = response.json()
        return render_template('index.html', cats=cats_data)
    else:
        return f"Error: {response.status_code}"

if __name__ == '__main__':
    app.run(debug=True)
