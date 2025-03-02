# Determining the reliability of communication between two nodes of a computer network

## Overview

This project is a C# application developed for a coding competition hosted by Bauman Moscow State Technical University. It aims to determine the reliability of communication between two nodes in a computer network by comparing two distinct methods: an experimental (simulation-based) method and an analytical (logic-based) method.

## Purpose

The primary goal of the project is to evaluate and compare different approaches to assessing network reliability. In this context, reliability is defined as the probability that a signal originating from a source node (A) will successfully reach a destination node (B). The project provides insights into the strengths and trade-offs of each method:

- **Experimental Method:** Uses a Monte Carlo simulation approach by performing a large number of experiments. In each experiment, node failures are simulated based on given reliability values, and the existence of at least one path from the source to the destination is checked.
- **Analytical Method:** Employs logical analysis using techniques such as disjunctive normal forms (DNF), truth tables, and the inclusion-exclusion principle to compute the exact probability of successful communication.

## Features

- **Graph-Based Network Modeling:**  
  Users can represent a computer network as a graph where:
  - **Nodes** represent devices (e.g., computers, sensors, routers) with associated reliability probabilities.
  - **Edges** represent ideal, failure-free communication channels between nodes.

- **Reliability Calculation:**
  - **Experimental Approach:**  
    Simulates multiple iterations to randomly determine node failures and checks for connectivity between selected source and destination nodes. The ratio of successful experiments approximates the network’s reliability.
  - **Analytical Approach:**  
    Constructs a logical expression representing all possible paths and uses probability theory (including the inclusion-exclusion principle) to compute an exact reliability value.

- **Path Finding Algorithms:**
  - **Breadth-First Search (BFS):**  
    Quickly finds any available path between the source and destination nodes.
  - **Depth-First Search (DFS):**  
    Enumerates all possible paths between the nodes, useful for detailed analysis.

- **Node Influence Rating:**  
  Provides a rating for each node that reflects its impact on the overall reliability, helping identify potential bottlenecks or “weak points” in the network.

- **User Interface:**  
  Built using Windows Forms, the UI allows users to:
  - Create and connect nodes visually.
  - Set the reliability of each node.
  - Select source and destination nodes.
  - Execute either the experimental or analytical method.
  - View results, including detailed node ratings and graphical representations of error versus the number of experiments.

## How It Works

1. **Input Data Format:**  
   The network is input as a graph. The user manually creates nodes (each with a specified reliability) and edges (representing communication links). The user also selects a source node (signal origin) and a destination node (signal target).

2. **Experimental Method:**  
   - For a user-specified number of iterations, the program simulates node failures based on their reliability.
   - After each simulation, it checks if there is at least one path from the source to the destination.
   - The reliability is approximated as the ratio of successful experiments to the total number of experiments.
   - This method is highly scalable and allows a trade-off between speed and accuracy by adjusting the number of experiments.

3. **Analytical Method:**  
   - The program models the successful transmission event as a logical expression based on the status (working or failed) of nodes.
   - It then simplifies the expression into a full disjunctive normal form (FDNF), ensuring that each term is mutually exclusive.
   - Using principles of probability (such as the inclusion-exclusion principle), the exact reliability is computed.
   - This method provides precise results but may become computationally intensive with large or complex networks.

4. **Auxiliary Algorithms:**  
   - **BFS and DFS:** Used to search for paths between nodes.
   - **Bitwise Operations:** Employed in the analytical method to optimize the computation of the logical expressions.

## Project Structure

The project is organized into several key classes:

- **MainForm:**  
  The primary window for user interaction, where the network graph is built and manipulated.

- **NodeRatingForm:**  
  Displays a table with node ratings, indicating the influence each node has on the overall reliability.

- **Graph:**  
  Represents the network model, holding nodes, edges, and computed paths.

- **Node:**  
  Represents an individual network node, including its reliability value and connections.

- **Path:**  
  Represents a sequence of nodes forming a communication path.

- **Experimentor:**  
  Handles the simulation and computation for the experimental method.

- **PathSearcher:**  
  Implements algorithms for finding paths (BFS for any path and DFS for all paths).

- **AnalyticalProcessor:**  
  Implements the analytical method, including logical expression management and probability calculations.

- **LinearLogicEquation & GraphEventProbabilityProvider:**  
  Support the analytical computations by representing logical expressions and mapping node indices to their probabilities.

For a visual representation of the project structure, refer to the class diagram below:

![Class Diagram]([link-to-class-diagram-image](https://private-user-images.githubusercontent.com/29887385/418311926-b11f2689-1579-44ea-b8be-0f4ce2a5c29d.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NDA4NzM2NDAsIm5iZiI6MTc0MDg3MzM0MCwicGF0aCI6Ii8yOTg4NzM4NS80MTgzMTE5MjYtYjExZjI2ODktMTU3OS00NGVhLWI4YmUtMGY0Y2UyYTVjMjlkLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNTAzMDElMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjUwMzAxVDIzNTU0MFomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTQ0ODlkN2NhMjcyMGU5MmExNDU1YjZiYjFiOTg0NGJjNjJhYTY2ZjFkNzE1YjExMmQ0MDgzZDEyODA3MmFkOTImWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.sqnvcUAHUONGmjNJjKJB_IeUf0BkJaC22Jv9HS4rokw))

## Screenshots

Here are some screenshots illustrating various aspects of the application:

- **Main User Interface:**  
  ![Main UI](link-to-main-ui-screenshot)
- **Node Rating Table:**  
  ![Node Rating]([link-to-node-rating-screenshot](https://private-user-images.githubusercontent.com/29887385/418312083-18f1e9e7-9762-4545-8fd1-90ace2893f56.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NDA4NzQxODAsIm5iZiI6MTc0MDg3Mzg4MCwicGF0aCI6Ii8yOTg4NzM4NS80MTgzMTIwODMtMThmMWU5ZTctOTc2Mi00NTQ1LThmZDEtOTBhY2UyODkzZjU2LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNTAzMDIlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjUwMzAyVDAwMDQ0MFomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTYzYzg1MWEzYjNkZmM4OTgxODgzNDNkMjUwMWMxOGQwMWY5ZmQ5NmNhNDQyMzJjZDY2NjYwZTUzNWM3MTYwYWUmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.lIxa30CK1nYKSLAgMcjIW89ZCnANkE_joJTr0bTp6_8))
- **Experimental Method Output:**  
  ![Experimental Output]([link-to-experimental-output-screenshot](https://github.com/user-attachments/assets/8cea005a-f871-4c8e-8292-40a12377a7e4))
- **Analytical Method Output:**  
  ![Analytical Output]([link-to-analytical-output-screenshot](https://private-user-images.githubusercontent.com/29887385/418312140-2b9e6e66-583c-4a8b-940d-8c1f298ce8e3.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NDA4NzQxODAsIm5iZiI6MTc0MDg3Mzg4MCwicGF0aCI6Ii8yOTg4NzM4NS80MTgzMTIxNDAtMmI5ZTZlNjYtNTgzYy00YThiLTk0MGQtOGMxZjI5OGNlOGUzLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNTAzMDIlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjUwMzAyVDAwMDQ0MFomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTc3YTQwMTNlNjU2MzYzNjQxYTcyMDg4Y2VhYzBlZjc3NjdmYTY3YzBjMGVhODEyMmJlOWZjMzczMmY1MjYzOWQmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.RZB27zI4HTk1HdVirIjD2y-huFoV6gudrGvs9gm-aho))
- **Experimental Error Graph:**  
  ![Error Graph]([link-to-error-graph-screenshot](https://private-user-images.githubusercontent.com/29887385/418312038-e22e2845-0199-4eb3-b8c1-5b76e48246d9.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NDA4NzQxODAsIm5iZiI6MTc0MDg3Mzg4MCwicGF0aCI6Ii8yOTg4NzM4NS80MTgzMTIwMzgtZTIyZTI4NDUtMDE5OS00ZWIzLWI4YzEtNWI3NmU0ODI0NmQ5LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNTAzMDIlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjUwMzAyVDAwMDQ0MFomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTVlN2UzNzA1MWJjNDkyMmRiYzA2M2I5NTEwODk3MjI3YjkxMjllZjQ4YzIxMTE2MTAxYjQxMWI1MDE0ZmZlMWImWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.1ZTNBU4gDA8D7pRbnkK0_wANctFZmIpSX1Chl8WpdGI))

## Conclusion

This project demonstrates two contrasting methods for determining the reliability of network communication. The experimental method offers a flexible, scalable solution suitable for large networks, while the analytical method delivers exact results, though at a higher computational cost. Together, they provide a comprehensive toolset for analyzing and optimizing the performance and reliability of computer networks.
