// Jenkinsfile
pipeline {
    agent {
        docker { image 'mcr.microsoft.com/dotnet/sdk:8.0' }
    }

    stages {
        // Same as 'npm install' or 'pip install'.
        // Downloads all the NuGet packages defined in your .csproj files.
        stage('Restore Dependencies') {
            steps {
                echo 'Restoring NuGet packages...'
                // 'dotnet restore' is the command to download dependencies.
                sh 'dotnet restore'
            }
        }
        // This compiles both the main app and the test project.
        // Also triggers Reqnroll to generate test code from your .feature files.
        stage('Build') {
            steps {
                echo 'Building the solution...'
                sh 'dotnet build --configuration Release --no-restore'
            }
        }
        stage('Test') {
            steps {
                echo 'Running tests...'
                sh 'dotnet test --no-build --verbosity normal'
            }
        }
    }

    post {
        always {
            echo 'Pipeline has finished.'
        }
        success {
            echo 'Build and all tests passed successfully!'
        }
        failure {
            echo 'Build or tests failed.'
        }
    }
}